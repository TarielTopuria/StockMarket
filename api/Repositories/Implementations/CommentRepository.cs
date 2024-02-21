using System.Data.Common;
using api.Data;
using api.DTOs.Comment;
using api.Handlers.CustomExceptions;
using api.Models;
using api.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations
{
    public class CommentRepository(AppDbContext context, IMapper mapper) : ICommentRepository
    {
        private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<List<CommentResponseDTO>?> GetCommentsAsync()
        {
            try
            {
                var comments = await _context.Comments.ToListAsync();
                return _mapper.Map<List<CommentResponseDTO>>(comments);
            }
            catch (DbException ex)
            {
                throw new DatabaseException($"Database operation failed: {ex}");
            }
        }

        public async Task<CommentResponseDTO?> GetCommentByIdAsync(int id)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(id);
                return comment != null ? _mapper.Map<CommentResponseDTO>(comment) : null;
            }
            catch (DbException ex)
            {
                throw new DatabaseException($"Database operation failed: {ex}");
            }
        }

        public async Task<Comment?> CreateCommentAsync(int stockId, CommentRequestDTO commentDTO)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentDTO);
                comment.StockId = stockId;

                await _context.Comments.AddAsync(comment);
                var result = await _context.SaveChangesAsync();

                return result > 0 ? _mapper.Map<Comment>(comment) : null;
            }
            catch (DbException ex)
            {
                throw new DatabaseException($"Database operation failed: {ex}");
            }
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            try
            {
                var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

                if(commentModel is null)
                {
                    return false;
                }

                _context.Comments.Remove(commentModel);
                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (DbException ex)
            {
                throw new DatabaseException($"Database operation failed: {ex}");
            }
        }

        public async Task<CommentResponseDTO?> UpdateAsync(int id, UpdateCommentDTO modifiedComment)
        {
            try
            {
                var existingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

                if (existingComment is null)
                {
                    return null;
                }

                existingComment.Title = modifiedComment.Title;
                existingComment.Content = modifiedComment.Content;

                var result = await _context.SaveChangesAsync();

                return result > 0 ? _mapper.Map<CommentResponseDTO>(existingComment) : null;
            }
            catch (DbException ex)
            {
                throw new DatabaseException($"Database operation failed: {ex}");
            }
        }

        public async Task<bool> CommentExists(int id)
        {
            try
            {
                return await _context.Comments.AnyAsync(x => x.Id == id);
            }
            catch (DbException ex)
            {
                throw new DatabaseException($"Database operation failed: {ex}");
            }
        }
    }
}
