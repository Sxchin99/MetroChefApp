using MetroChefApp.API.Models;

namespace MetroChefApp.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        bool Save();
    }
}
