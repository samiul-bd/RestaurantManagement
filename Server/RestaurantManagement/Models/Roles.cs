using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal BasicSalary { get; set; } = 0;
        public bool CanApplyDiscount { get; set; } = false;
        public bool CanDeleteOrder { get; set; } = false;
        public bool CanManageUsers { get; set; } = false;

        public ICollection<Users> Users { get; set; } = new List<Users>();

    }
}
