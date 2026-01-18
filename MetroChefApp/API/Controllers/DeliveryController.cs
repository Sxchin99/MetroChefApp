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
    public class DeliveryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DeliveryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetDeliveries()
        {
            var deliveries = await _context.Deliveries.ToListAsync();
            return Ok(_mapper.Map<List<DeliveryDto>>(deliveries));
        }

        // GET: api/Delivery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDto>> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null) return NotFound();

            return Ok(_mapper.Map<DeliveryDto>(delivery));
        }

        // POST: api/Delivery
        [HttpPost]
        public async Task<ActionResult<DeliveryDto>> CreateDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();

            var deliveryDto = _mapper.Map<DeliveryDto>(delivery);
            return CreatedAtAction(nameof(GetDelivery), new { id = delivery.DeliveryId }, deliveryDto);
        }

        // PUT: api/Delivery/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, Delivery updatedDelivery)
        {
            if (id != updatedDelivery.DeliveryId) return BadRequest();

            _context.Entry(updatedDelivery).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Delivery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null) return NotFound();

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
