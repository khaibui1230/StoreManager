using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Model;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService staffService;

        public StaffController(IStaffService staffService)
        {

            this.staffService = staffService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStaffsAsync()
        {
            var staffs = await staffService.GetAllStaffsAsync();
            return Ok(staffs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffByIdAsync(int id)
        {
            var staff = await staffService.GetStaffByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }
        [HttpPost]
        public async Task<IActionResult> AddStaffAsync(StaffDto staffDto)
        {
            if (staffDto == null || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid staff data" });
            }

            var newStaff = await staffService.AddStaffAsync(staffDto);
            if (newStaff == null || newStaff.Id <= 0)
            {
                return StatusCode(500, new { message = "Failed to create staff" });
            }

            Console.WriteLine($"New staff ID: {newStaff.Id}"); // Debug
            return CreatedAtAction("GetStaffById", new { id = newStaff.Id }, newStaff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffAsync(StaffDto staffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedStaff = await staffService.UpdateStaffAsync(staffDto);
            if (updatedStaff == null)
            {
                return NotFound(new { message = "Staff not found" });
            }

            return NoContent();
        }
    }
}
