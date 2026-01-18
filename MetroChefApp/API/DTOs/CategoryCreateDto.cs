namespace MetroChefApp.API.DTOs
{
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
