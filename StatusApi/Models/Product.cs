using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StatusApi.Models;

namespace StatusERP.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        public int CurrentStock { get; set; }

        public int MinimumStock { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant? Restaurant { get; set; }
    }
}
