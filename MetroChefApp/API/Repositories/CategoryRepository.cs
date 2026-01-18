using MetroChefApp.API.Data;
using MetroChefApp.API.Models;
using MetroChefApp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;  // for Include() and EF features


namespace MetroChefApp.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
