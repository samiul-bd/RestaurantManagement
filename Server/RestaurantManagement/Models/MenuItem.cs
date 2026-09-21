using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 999999.99, ErrorMessage = "Price cannot be negative.")]
        public decimal Price { get; set; }        
        public bool IsAvailable { get; set; } = true;        
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
