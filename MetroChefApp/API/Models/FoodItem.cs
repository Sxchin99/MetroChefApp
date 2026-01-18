using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class FoodItem
    {
        [Key]  // ✅ Primary key
        public int FoodId { get; set; }  

        [Required]
        public int CategoryId { get; set; }  

        [Required]
        public string FoodName { get; set; }  

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }  

        public string? Description { get; set; }

        public bool IsAvailable { get; set; }

        public string? ImageUrl { get; set; }

        // Navigation property (optional)
        public Category? Category { get; set; }
    }
}
