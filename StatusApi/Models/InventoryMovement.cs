using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StatusApi.Models;

namespace StatusERP.Domain.Models
{
    public enum MovementType
    {
        In = 1,
        Out = 2
    }

    [Table("InventoryMovement")]
    public class InventoryMovement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public MovementType Type { get; set; }

        public int Quantity { get; set; }

        [MaxLength(100)]
        public string? Reason { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}
