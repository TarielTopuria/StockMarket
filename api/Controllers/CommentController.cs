using api.DTOs.Comment;
using api.Handlers.CustomExceptions;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommentController(ICommentRepository commentRepository, IStockRepository stockRepository) : Controller
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IStockRepository _stockRepository = stockRepository;

        [HttpGet]
        [Route("GetComments")]
        public async Task<ActionResult<List<CommentResponseDTO>>> GetComments()
        {
            try
            {
                var result = await _commentRepository.GetCommentsAsync();

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResponseDTO>> GetCommentById(int id)
        {
            try
            {
                var result = await _commentRepository.GetCommentByIdAsync(id);

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex}");
            }
        }

        [HttpPost("{stockId}/AddComment")]
        public async Task<ActionResult<CommentResponseDTO>> AddComment([FromRoute] int stockId, CommentRequestDTO comment)
        {
            try
            {
                if (!await _stockRepository.StockExists(stockId))
                {
                    return NotFound("Stock not found");
                }

                var newComment = await _commentRepository.CreateCommentAsync(stockId, comment);

                if (newComment is null)
                {
                    return BadRequest("Incorrect Request: Nothing changed in the database");
                }

                return CreatedAtAction(nameof(GetCommentById), new { newComment.Id }, comment);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            try
            {
                var existingComment = await _commentRepository.CommentExists(id);

                if(!existingComment)
                {
                    return NotFound("Comment not found");
                }

                var result = await _commentRepository.DeleteCommentAsync(id);

                if (!result)
                {
                    return BadRequest("Error occured due to bad request when deleting comment.");
                }

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex}");
            }
        }
    }
}
