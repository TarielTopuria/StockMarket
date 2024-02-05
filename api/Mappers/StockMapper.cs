using api.DTOs.Comment;
using api.DTOs.Stock;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class StockMapper : Profile
    {
        public StockMapper()
        {
            CreateMap<Stock, StockResponseDTO>();
            CreateMap<StockRequestDTO, Stock>();
            CreateMap<UpdateStockRequestDTO, StockResponseDTO>();
            CreateMap<Comment, CommentResponseDTO>();
        }
    }
}
