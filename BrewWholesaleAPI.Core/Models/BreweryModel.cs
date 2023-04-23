using System.ComponentModel.DataAnnotations;

namespace BrewWholesaleAPI.Core.Models
{
    public class BreweryModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [Required]
        public bool? IsDeleted { get; set; }

    }
}
