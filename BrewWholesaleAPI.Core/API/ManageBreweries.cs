using BrewWholesaleAPI.Core.Data;
using BrewWholesaleAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewWholesaleAPI.Core.API
{
    public static class ManageBreweries
    {
        #region Public Methods

        public static List<BreweryModel?> GetList()
        {
            return new Brewery().List().Select(t => (BreweryModel?)t).ToList(); ;
        }

        public static BreweryModel? Save(BreweryModel model)
        {
            if (model != null)
            {

                BreweryModel? brewery = new BreweryModel();

                if ((model.Id?? 0) == 0)
                {
                    model.CreateDate = DateTime.Now;
                    brewery = Brewery.Insert(model);
                }
                else
                {
                    model.ModifyDate = DateTime.Now;
                    brewery = Brewery.Update(model);
                }
                return brewery;
            }
            return null;
        } 

        #endregion

    }
}
