using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int FoodId { get; set; }
        public FoodItem FoodItem { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
