namespace MetroChefApp.API.DTOs
{
    public class FoodItemCreateDto
    {
        public int CategoryId { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string? ImageUrl { get; set; }
    }
}
