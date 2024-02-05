using api.DTOs.Comment;

namespace api.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<CommentResponseDTO>?> GetCommentsAsync();
        Task<CommentResponseDTO?> GetCommentByIdAsync(int id);
    }
}
