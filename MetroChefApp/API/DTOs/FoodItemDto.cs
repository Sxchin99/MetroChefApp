public class FoodItemDto
{
    public int FoodId { get; set; }
    public int CategoryId { get; set; }
    public string FoodName { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public string? ImageUrl { get; set; }
    public string? CategoryName { get; set; } // Optional
}

