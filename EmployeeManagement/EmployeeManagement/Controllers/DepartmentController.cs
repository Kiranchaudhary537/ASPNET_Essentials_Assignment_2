using EmployeeManagement.Dtos;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DepartmentController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                Id = departmentDto.Id,
                DepartmentName = departmentDto.DepartmentName
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDepartment(int id, DepartmentDto departmentDto)
        {
            if (id != departmentDto.Id)
            {
                return BadRequest();
            }

            var department = new Department
            {
                Id = departmentDto.Id,
                DepartmentName = departmentDto.DepartmentName
            };

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departments.Any(d => d.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
