using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCusAsync()
        {
            var customers = await customerService.GetAllCusAsync();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        [ActionName("GetCusById")]
        public async Task<IActionResult> GetCusByIdAsync(int id)
        {
            var customer = await customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> AddCusAsync(CustomerDto customerDto)
        {
            var customer = await customerService.AddCusAsync(customerDto);
            if (customer == null)
            {
                return BadRequest("Can not create Customer");
            }
            return CreatedAtAction(nameof(GetCusByIdAsync), new { id = customer.Id }, customer);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCusAsync(CustomerDto customerDto)
        {
            var customer = await customerService.UpdateCusAsync(customerDto);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCusAsync(int id)
        {
            var result = await customerService.DeleteCusAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
