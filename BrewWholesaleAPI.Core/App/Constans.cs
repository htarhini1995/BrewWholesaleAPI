using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewWholesaleAPI.Core.App
{
    public class ErrorMessages
    {
        public const string OrderEmpty = "The order cannot be empty";
        public const string WholesalerExist = "The wholesaler must exist";
        public const string NoDublicates = "There can't be any duplicate in the order";
        public const string Quantity = "The number of beers ordered cannot be greater than the wholesaler's stock";
        public const string NoWholesaler = "The beer must be sold by the wholesaler";
    }

    public class SaleSummery
    {
        public const string ListItem = "{0} --- Beer: {1}, Quantity: {2},TotalPrice: {3}€ --- \n";
        public const string TotalPrice = "{0} The total price of all beers is {1} €";
        public const string Discount = "{0} and The Price after discount is {1} €";
    }
}
