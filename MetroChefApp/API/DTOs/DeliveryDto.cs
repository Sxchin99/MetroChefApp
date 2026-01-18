namespace MetroChefApp.API.DTOs
{
    public class DeliveryDto
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;
    }
}
