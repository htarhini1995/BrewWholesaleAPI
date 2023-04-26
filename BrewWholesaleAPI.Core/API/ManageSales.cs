using BrewWholesaleAPI.Core.App;
using BrewWholesaleAPI.Core.Data;
using BrewWholesaleAPI.Core.Data.Models;
using BrewWholesaleAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Core.API
{
    public static class ManageSales
    {

        #region Private Methods

        private static decimal SaveBeerSales(SaleModel model, ref int totalQuantity)
        {
            decimal totalPrice = 0;
            model.Summery = string.Empty;
            if (model?.WholesalerId != 0)
            {
                var wholeSalerBeers = new WholeSalerBeer().ListByWholeSaler(model?.WholesalerId ?? 0);
                foreach (BeerSaleModel item in model.BeerSales)
                {
                    if (item?.BeerId != 0)
                    {
                        var wholeSalerBeer = wholeSalerBeers.FirstOrDefault(t => t?.BeerId == item?.BeerId);
                        if (wholeSalerBeer?.Quantity > item?.Quantity)
                        {
                            var beer = Beer.GetPrice(item?.BeerId ?? 0);
                            if (beer != null)
                            {
                                decimal price = beer?.Price ?? 0;
                                BeerSale beerSale = new BeerSale();
                                beerSale.Id = item?.Id ?? 0;
                                beerSale.BeerId = item?.BeerId;
                                beerSale.SaleId = model.Id;
                                beerSale.Quantity = item?.Quantity;
                                beerSale.Price = price * item?.Quantity;
                                beerSale.Insert();
                                totalPrice += beerSale.Price ?? 0;
                                totalQuantity += beerSale.Quantity ?? 0;
                                wholeSalerBeer.Quantity -= item?.Quantity;
                                wholeSalerBeer.Update();
                                model.Summery = string.Format(SaleSummery.ListItem, model.Summery, beer?.Name, beerSale?.Quantity, beerSale.Price);
                            }
                        }
                    }
                }
            }

            return totalPrice;
        }

        private static SaleValidationModel ValidateQuantity(SaleModel? model, ref SaleValidationModel validation)
        {
            if (model?.WholesalerId != 0)
            {
                var wholeSalerBeers = new WholeSalerBeer().ListByWholeSaler(model?.WholesalerId ?? 0);
                foreach (BeerSaleModel item in model?.BeerSales)
                {
                    if (item?.BeerId != 0)
                    {
                        var wholeSalerBeer = wholeSalerBeers.FirstOrDefault(t => t?.BeerId == item?.BeerId);
                        if (wholeSalerBeer?.Quantity < item?.Quantity)
                        {
                            validation.ErrorMessage = ErrorMessages.Quantity;
                            validation.IsValid = false;
                        }

                    }
                }
            }
            return validation;
        }

        #endregion

        #region Public Methods

        public static SaleModel? CreateQuoteSale(SaleModel model)
        {
            using (var transaction = Configuration.OpenContext(false).Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                try
                {
                    Sale? sale = null;

                    if (model?.Id == 0)
                    {
                        sale = new Sale
                        {
                            WholesalerId = model.WholesalerId
                        };
                        sale.Insert();
                        model.Id = sale.Id;
                        int totalQuantity = 0;
                        decimal totalPrice = SaveBeerSales(model, ref totalQuantity);
                        sale.TotalPrice = totalPrice;
                        sale.TotalDiscountedPrice = totalPrice;
                        model.TotalPrice = totalPrice;
                        model.TotalDiscountedPrice = totalPrice;
                        if ((model?.IsQuote) ?? false)
                        {
                            var discount = Discount.FindbyQuantity(totalQuantity);
                            if (discount != null)
                            {
                                sale.DiscountId = discount.Id;
                                decimal discountAmmount = ((decimal)((discount?.Amount ?? 0) / 100));
                                if (discountAmmount != 0)
                                {
                                    sale.TotalDiscountedPrice = totalPrice - (totalPrice * discountAmmount);
                                    model.TotalDiscountedPrice = sale.TotalDiscountedPrice;
                                }
                            }
                        }
                        sale?.Update();
                    }
                    transaction.Commit();

                    model.Summery = string.Format(SaleSummery.TotalPrice, model.Summery, model.TotalPrice);

                    if (model?.TotalPrice > model?.TotalDiscountedPrice)
                    {
                        model.Summery = string.Format(SaleSummery.Discount, model.Summery, model.TotalDiscountedPrice);
                    }

                    return model;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static SaleValidationModel Validate(SaleModel model)
        {

            SaleValidationModel retval = new SaleValidationModel
            {
                IsValid = true
            };

            if (model != null)
            {
                if (model?.BeerSales.Count == 0)
                {
                    retval.ErrorMessage = ErrorMessages.OrderEmpty;
                    retval.IsValid = false;
                    return retval;
                }

                if (model?.WholesalerId == 0)
                {
                    retval.ErrorMessage = ErrorMessages.NoWholesaler;
                    retval.IsValid = false;
                    return retval;
                }

                var wholeSaler = new Wholesaler().Find(model?.WholesalerId ?? 0);

                if (wholeSaler == null)
                {
                    retval.ErrorMessage = ErrorMessages.WholesalerExist;
                    retval.IsValid = false;
                    return retval;
                }

                var list = model?.BeerSales.Select(t => t.BeerId).Distinct().ToList();

                if (list?.Count < model?.BeerSales.Count)
                {
                    retval.ErrorMessage = ErrorMessages.NoDublicates;
                    retval.IsValid = false;
                    return retval;
                }

                ValidateQuantity(model, ref retval);

            }

            return retval;
        }

        #endregion

    }
}
