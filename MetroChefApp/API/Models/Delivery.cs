using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models

{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
