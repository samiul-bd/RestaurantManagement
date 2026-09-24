using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class Users 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? PinCode { get; set; }
        public bool IsActive { get; set; }

        //HR Properties
        public DateOnly JoinDate { get; set; }
        public DateOnly? ResignDate { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles Role { get; set; } = null!;
    }
}

