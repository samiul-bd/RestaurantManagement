using RestaurantManagement.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public string TableNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public TableStatusEnum TableStatus { get; set; } = TableStatusEnum.Available;
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}