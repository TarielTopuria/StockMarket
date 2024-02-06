using api.DTOs.Stock;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<List<StockResponseDTO>?> GetStocksAsync();
        Task<StockResponseDTO?> GetStockByIdAsync(int id);
        Task<StockResponseDTO?> CreateStockAsync(StockRequestDTO stock);
        Task<StockResponseDTO?> UpdateStockAsync(int id, UpdateStockRequestDTO request);
        Task<bool?> DeleteStock(int id);
        Task<bool> StockExists(int id);
    }
}
