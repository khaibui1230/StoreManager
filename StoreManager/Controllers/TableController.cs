using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Model;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TableController : ControllerBase
    {
        private readonly ITableService tableService;

        public TableController(ITableService tableService)
        {
            this.tableService = tableService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> GetAllTables()
        {
            var tables = await tableService.GetAllTableAsync();
            return Ok(tables);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDto>> GetTableById(int id)
        {
            var table = await tableService.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }
        [HttpPost]
        public async Task<ActionResult<TableDto>> AddTable(TableDto tableDto)
        {
            if (tableDto == null || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid table data" });
            }
            var newTable = await tableService.AddTableAsync(tableDto);
            if (newTable == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtAction(nameof(GetTableById), new { id = newTable.Id }, newTable);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(TableDto tableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTable = await tableService.UpdateTableAsync(tableDto);
            if (updatedTable == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var deletedTable = await tableService.DeleteTableAsync(id);
            if (!deletedTable)
            {
                var table = await tableService.GetTableByIdAsync(id);
                if (table == null)
                {
                    return NotFound(new { message = $"Table with ID {id} not found" });
                }
                return BadRequest(new { message = $"Staff with ID {id} cannot be deleted due to existing orders" });

            }          
            return NoContent();
        }

    }
}
