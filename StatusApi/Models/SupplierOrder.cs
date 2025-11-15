using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StatusApi.Models;

namespace StatusERP.Domain.Models
{
    public enum SupplierOrderStatus
    {
        Pending,
        Delivered,
        Received
    }

    [Table("SupplierOrder")]
    public class SupplierOrder
    {
        [Key]
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public int SupplierId { get; set; }

        public DateTime OrderDate { get; set; }

        public SupplierOrderStatus Status { get; set; }

        public decimal Total { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant? Restaurant { get; set; }
    }
}
