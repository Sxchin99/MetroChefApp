using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class OrderStatusHistory
    {
        [Key]
        public int StatusId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string Status { get; set; }
        public int? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
