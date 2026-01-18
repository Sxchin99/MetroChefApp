using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<FoodItem> FoodItems { get; set; }
    }
}
