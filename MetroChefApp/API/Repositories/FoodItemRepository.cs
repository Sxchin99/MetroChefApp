using MetroChefApp.API.Data;
using MetroChefApp.API.Models;
using MetroChefApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace MetroChefApp.API.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly AppDbContext _context;

        public FoodItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodItem> GetAll()
        {
            return _context.FoodItems
                           .Include(f => f.Category)
                           .ToList();
        }

        public IEnumerable<FoodItem> GetAvailableFoodItems()
        {
            return _context.FoodItems
                           .Include(f => f.Category)
                           .Where(f => f.IsAvailable)
                           .ToList();
        }

        public FoodItem? GetById(int id)
        {
            return _context.FoodItems
                           .Include(f => f.Category)
                           .FirstOrDefault(f => f.FoodId == id);
        }

        public void Add(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);
        }

        public void Update(FoodItem foodItem)
        {
            _context.FoodItems.Update(foodItem);
        }

        public void Delete(int id)
        {
            var foodItem = GetById(id);
            if (foodItem != null)
            {
                _context.FoodItems.Remove(foodItem);
            }
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
