using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatusERP.Domain.Models
{
    [Table("SupplierOrderDetail")]
    public class SupplierOrderDetail
    {
        [Key]
        public int Id { get; set; }

        public int SupplierOrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal { get; set; }
    }
}
