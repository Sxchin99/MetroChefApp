using MetroChefApp.API.Models;

namespace MetroChefApp.API.Repositories.Interfaces
{
    public interface IFoodItemRepository
    {
        IEnumerable<FoodItem> GetAll();
        IEnumerable<FoodItem> GetAvailableFoodItems();
        FoodItem? GetById(int id);
        void Add(FoodItem foodItem);
        void Update(FoodItem foodItem);
        void Delete(int id);
        bool Save();
    }
}
