using api.DTOs.Stock;
using api.Models;
using api.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public StockController(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetStocks")]
        public async Task<ActionResult<List<StockResponseDTO>>> GetAllStock()
        {
            try
            {
                var result = await _stockRepository.GetStocksAsync();
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

        [HttpGet]
        [Route("GetStock")]
        public async Task<ActionResult<List<StockResponseDTO>>> GetStockById([FromQuery] int id)
        {
            try
            {
                var result = await _stockRepository.GetStockByIdAsync(id);

                if (result is null)
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

        [HttpPost]
        [Route("CreateStock")]
        public async Task<ActionResult<StockResponseDTO>> CreateStock([FromBody] StockRequestDTO stock)
        {
            try
            {
                var result = await _stockRepository.CreateStockAsync(stock);
                
                if (result == null)
                {
                    return BadRequest("Nothing Created");
                }

                return CreatedAtAction(nameof(GetStockById), new { result.Id }, stock);

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

        [HttpPut]
        [Route("UpdateStocks")]
        public async Task<ActionResult<StockResponseDTO>> UpdateStock([FromQuery] int id, [FromBody] UpdateStockRequestDTO request)
        {
            try
            {
                var result = await _stockRepository.UpdateStockAsync(id, request);

                if (result is null)
                {
                    return NotFound();
                }

                if (result.Symbol is null)
                {
                    return BadRequest("Nothing to change");
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

        [HttpDelete]
        [Route("DeleteStock")]
        public async Task<IActionResult> DeleteStock([FromQuery]int id)
        {
            try
            {
                var result = await _stockRepository.DeleteStock(id);

                if(result is null)
                {
                    return NotFound();
                }

                if ((bool)!result)
                {
                    return BadRequest("Nothing to change");
                }

                return NoContent();
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
