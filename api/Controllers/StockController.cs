using api.DTOs.Stock;
using api.Helpers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StockController(IStockService stockService) : ControllerBase
    {
        private readonly IStockService _stockService = stockService;

        [HttpGet("GetStocks")]
        public async Task<ActionResult<List<StockResponseDTO>>> GetAllStocks([FromQuery] QueryObject query)
        {
            try
            {
                var stocks = await _stockService.GetAllStocksAsync(query);
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetStock/{id}")]
        public async Task<ActionResult<StockResponseDTO>> GetStockById(int id)
        {
            try
            {
                var stock = await _stockService.GetStockByIdAsync(id);
                if (stock == null)
                {
                    return NotFound();
                }
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("CreateStock")]
        public async Task<ActionResult<StockResponseDTO>> CreateStock([FromBody] StockRequestDTO stockDTO)
        {
            try
            {
                var createdStock = await _stockService.CreateStockAsync(stockDTO);
                return CreatedAtAction(nameof(GetStockById), new { id = createdStock.Id }, createdStock);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("UpdateStock/{id}")]
        public async Task<ActionResult<StockResponseDTO>> UpdateStock(int id, [FromBody] UpdateStockRequestDTO stockDTO)
        {
            try
            {
                var updatedStock = await _stockService.UpdateStockAsync(id, stockDTO);
                if (updatedStock == null)
                {
                    return NotFound();
                }
                return Ok(updatedStock);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("DeleteStock/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            try
            {
                var success = await _stockService.DeleteStockAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
