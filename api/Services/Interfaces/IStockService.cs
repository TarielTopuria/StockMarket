using api.DTOs.Stock;
using api.Helpers;

namespace api.Services.Interfaces
{
    public interface IStockService
    {
        Task<List<StockResponseDTO>> GetAllStocksAsync(QueryObject query);
        Task<StockResponseDTO?> GetStockByIdAsync(int id);
        Task<StockResponseDTO> CreateStockAsync(StockRequestDTO stockDTO);
        Task<StockResponseDTO?> UpdateStockAsync(int id, UpdateStockRequestDTO stockDTO);
        Task<bool> DeleteStockAsync(int id);
    }

}
