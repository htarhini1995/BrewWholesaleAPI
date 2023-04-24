using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class BeerModel
{
    public int? Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required]
    public double? AlcoholAmmount { get; set; }

    [Required]
    public int? Price { get; set; }

    [Required]
    public int? BreweryId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public bool? IsDeleted { get; set; }

    public Brewery? Brewery { get; set; }

}
