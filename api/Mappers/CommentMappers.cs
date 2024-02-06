using api.DTOs.Comment;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class CommentMappers : Profile
    {
        public CommentMappers()
        {
            CreateMap<Comment, CommentResponseDTO>();
            CreateMap<CommentRequestDTO, Comment>();
        }
    }
}
