using BrewWholesaleAPI.Core.Data;
using BrewWholesaleAPI.Core.Data.Models;

namespace BrewWholesaleAPI.Core.API
{
    public static class ManageBeers
    {

        #region Public Methods

        public static List<BeerModel?> GetList()
        {
            return new Beer().List().Select(t => (BeerModel?)t).ToList(); ;
        }

        public static List<BeerModel?> GetListByBrewery(int breweryId)
        {
            return new Beer().ListByBrewery(breweryId).Select(t => (BeerModel?)t).ToList(); ;
        }

        public static BeerModel? Save(BeerModel model)
        {
            if (model != null)
            {
                BeerModel? beer = new BeerModel();

                if ((model.Id ?? 0) == 0)
                {
                    model.CreateDate = DateTime.Now;
                    beer = Beer.Insert(model);
                }
                else
                {
                    model.ModifyDate = DateTime.Now;
                    beer = Beer.Update(model);
                }
                return beer;
            }
            return null;
        }

        public static void Delete(int id)
        {
            new Beer().Delete(id);
        }

        public static void MarkAsDeleted(int id)
        {
            Beer beer = new Beer().Find(id);
            if (beer != null)
            {
                beer.IsDeleted = true;
                beer.Update();
            }
        }

        public static WholeSalerBeer? UpdateBeerQuantity(WholeSalerBeerModel model)
        {
            if (model != null)
            {
                WholeSalerBeer? quantity = (WholeSalerBeer?)model;

                if (quantity?.Id == 0)
                {
                    quantity?.Insert();
                }
                else
                {
                    quantity?.Update();
                }
                return quantity;
            }
            return null;
        }

        #endregion

    }
}
