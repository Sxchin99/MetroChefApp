using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string OrderType { get; set; } // PICKUP / DELIVERY
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; }
        public Delivery Delivery { get; set; }
    }
}
