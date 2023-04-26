using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewWholesaleAPI.Core.Models
{
    public class SaleValidationModel
    {
        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
