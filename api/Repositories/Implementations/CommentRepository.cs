using api.Data;
using api.DTOs.Comment;
using api.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations
{
    public class CommentRepository (AppDbContext context, IMapper mapper) : ICommentRepository
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CommentResponseDTO>?> GetCommentsAsync()
        {
            var comments = await _context.Comments.ToListAsync();
            
            if(comments is null)
            {
                return null;
            }

            List<CommentResponseDTO> mappedComments = _mapper.Map<List<CommentResponseDTO>>(comments);

            return mappedComments;
        }

        public async Task<CommentResponseDTO?> GetCommentByIdAsync(int id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(c => c.Id == id);
            
            if(comment == null)
            {
                return null;
            }

            var result = _mapper.Map<CommentResponseDTO>(comment);

            return result;
        }
    }
}
