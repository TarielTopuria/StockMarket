using api.DTOs.Comment;
using api.DTOs.Stock;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<CommentResponseDTO>?> GetCommentsAsync();
        Task<CommentResponseDTO?> GetCommentByIdAsync(int id);
        Task<Comment?> CreateCommentAsync(int stockId, CommentRequestDTO commentDTO);
        Task<bool> DeleteCommentAsync(int id);
        Task<bool> CommentExists(int id);
    }
}
