using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Model;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAllStaffs()
        {
            var staffs = await staffService.GetAllStaffsAsync();
            return Ok(staffs);
        }
        [HttpGet("{id}")]
        [ActionName("GetStaffById")] //
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await staffService.GetStaffByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
            return CreatedAtAction(nameof(GetStaffById), new { id = newStaff.Id }, newStaff);
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
        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteStaffAsync(int id)
        {
            var deletedStaff = await staffService.DeleteStaffAsync(id);
            if (!deletedStaff)
            {
                var staff = await staffService.GetStaffByIdAsync(id);
                if (staff ==null)
                {
                    return NotFound(new { message = $"Staff with ID {id} not found" });
                }
                return BadRequest(new { message = $"Staff with ID {id} cannot be deleted due to existing orders" });
            }

            return NoContent();
        }
    }
}
