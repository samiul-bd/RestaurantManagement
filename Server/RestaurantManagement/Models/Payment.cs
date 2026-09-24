using RestaurantManagement.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class Payment : TenantBase
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; } 

        public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.Cash;
        public string? TransactionId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;
    }
}
