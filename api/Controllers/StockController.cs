using api.Models;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAllStock() 
        {
            try
            {
                return Ok(await _stockRepository.GetStocksAsync());
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Stock>>> GetStockById([FromRoute] int id)
        {
            try
            {
                var result = await _stockRepository.GetStockByIdAsync(id);
                if(result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}
