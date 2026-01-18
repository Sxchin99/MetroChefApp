using MetroChefApp.API.Models;
using MetroChefApp.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MetroChefApp.API.DTOs;

namespace MetroChefApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemRepository _foodRepo;
        private readonly IMapper _mapper;   // ✅ ADD THIS

        public FoodItemController(IFoodItemRepository foodRepo, IMapper mapper)
        {
            _foodRepo = foodRepo;
            _mapper = mapper;
        }

        // GET: api/fooditem
        [HttpGet]
        public IActionResult GetAll()
        {
            var foodItems = _foodRepo.GetAll();
            var foodItemDtos = _mapper.Map<List<FoodItemDto>>(foodItems);
            return Ok(foodItemDtos);
        }


        // GET: api/fooditem/available
        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            var items = _foodRepo.GetAvailableFoodItems();
            return Ok(items);
        }

        // GET: api/fooditem/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _foodRepo.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // POST: api/fooditem
        [HttpPost]
        public IActionResult Create(FoodItemCreateDto dto)
        {
            var foodItem = _mapper.Map<FoodItem>(dto);

            _foodRepo.Add(foodItem);
            _foodRepo.Save();

            return Ok(_mapper.Map<FoodItemDto>(foodItem));
        }


        // PUT: api/fooditem/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FoodItem item)
        {
            var existing = _foodRepo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.FoodName = item.FoodName;
            existing.Price = item.Price;
            existing.IsAvailable = item.IsAvailable;
            existing.Description = item.Description;
            existing.ImageUrl = item.ImageUrl;
            existing.CategoryId = item.CategoryId;

            _foodRepo.Update(existing);
            _foodRepo.Save();

            return NoContent();
        }

        // DELETE: api/fooditem/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _foodRepo.GetById(id);
            if (existing == null)
                return NotFound();

            _foodRepo.Delete(id);
            _foodRepo.Save();

            return NoContent();
        }
    }
}
