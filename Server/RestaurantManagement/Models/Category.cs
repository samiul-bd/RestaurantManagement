using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
