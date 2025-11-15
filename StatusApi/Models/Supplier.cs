using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StatusApi.Models;

namespace StatusERP.Domain.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        // before: EmpresaId
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant? Restaurant { get; set; }
    }
}
