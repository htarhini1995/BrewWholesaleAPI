using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class BeerSaleModel
{
    public int? Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? BeerId { get; set; }


    [Required]
    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }


}
