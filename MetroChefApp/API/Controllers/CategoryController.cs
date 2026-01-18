using AutoMapper;
using MetroChefApp.API.DTOs;
using MetroChefApp.API.Models;
using MetroChefApp.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetroChefApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryRepository categoryRepo,
            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        // GET: api/category
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryRepo.GetAll();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(result);
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        // POST: api/category
        [HttpPost]
        public IActionResult Create(CategoryCreateDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            _categoryRepo.Add(category);
            _categoryRepo.Save();

            var result = _mapper.Map<CategoryDto>(category);

            return CreatedAtAction(nameof(GetById),
                new { id = category.CategoryId },
                result);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryCreateDto dto)
        {
            var existing = _categoryRepo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.CategoryName = dto.CategoryName;
            existing.IsActive = dto.IsActive;

            _categoryRepo.Update(existing);
            _categoryRepo.Save();

            return NoContent();
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _categoryRepo.GetById(id);
            if (existing == null)
                return NotFound();

            _categoryRepo.Delete(id);
            _categoryRepo.Save();

            return NoContent();
        }
    }
}
