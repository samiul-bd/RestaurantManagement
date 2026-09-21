using RestaurantManagement.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        // automatic serialised string should generate like "ORD-20260921-001"
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Discount { get; set; } = 0;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TaxAmount { get; set; } = 0;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmount { get; set; } = 0;

        public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Pending;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; } = null!;



        //if order placed for percel we should leave it nullable.
        public int? TableId { get; set; }
        [ForeignKey("TableId")]
        public Table? Table { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


        //Coupon properties.
        public int? CouponId { get; set; }

        [ForeignKey("CouponId")]
        public Coupon? Coupon { get; set; }

        public string?  Notes { get; set; }
    }
}
