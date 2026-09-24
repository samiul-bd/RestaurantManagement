using RestaurantManagement.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class Coupon : TenantBase
    {
        [Key]
        public int Id { get; set; }

        // Coupon Code: "EID2026", "WELCOME50")
        [Required]
        public string Code { get; set; } = string.Empty;

        public DiscountTypeEnum DiscountType { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal DiscountValue { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? MaxDiscountAmount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal MinOrderAmount { get; set; } = 0;       
        
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }

        public bool IsActive { get; set; } = true;

        public int? MaxUsageLimit { get; set; }
        public int UsedCount { get; set; } = 0;

    }
}
