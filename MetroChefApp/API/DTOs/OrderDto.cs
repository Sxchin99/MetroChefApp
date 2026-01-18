namespace MetroChefApp.API.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
        public List<OrderStatusDto>? StatusHistory { get; set; }
    }

    public class OrderItemDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class OrderStatusDto
    {
        public string Status { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
    }
}
