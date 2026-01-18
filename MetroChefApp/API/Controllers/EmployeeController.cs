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
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(e => e.WorkRosters)
                .Include(e => e.Salaries)
                .ToListAsync();

            return Ok(_mapper.Map<List<EmployeeDto>>(employees));
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.WorkRosters)
                .Include(e => e.Salaries)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null) return NotFound();

            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employeeDto);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            if (id != updatedEmployee.EmployeeId) return BadRequest();

            _context.Entry(updatedEmployee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
