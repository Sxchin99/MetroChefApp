using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetroChefApp.API.Data;
using MetroChefApp.API.DTOs;
using MetroChefApp.API.Models;

namespace MetroChefApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.FoodItem)
                .Include(o => o.OrderStatusHistories)
                .ToListAsync();

            return Ok(_mapper.Map<List<OrderDto>>(orders));
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.FoodItem)
                .Include(o => o.OrderStatusHistories)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null) return NotFound();

            return Ok(_mapper.Map<OrderDto>(order));
        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderDto = _mapper.Map<OrderDto>(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, orderDto);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order updatedOrder)
        {
            if (id != updatedOrder.OrderId) return BadRequest();

            _context.Entry(updatedOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
