using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Models
{
    public class Reservation : TenantBase
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;        
        public DateTime ReservationTime { get; set; }       
        public int GuestCount { get; set; }        
        public int TableId { get; set; }

        [ForeignKey("TableId")]
        public Table Table { get; set; } = null!;
    }
}