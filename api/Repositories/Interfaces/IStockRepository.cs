using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<List<Stock>?> GetStocksAsync(QueryObject query);
        Task<Stock?> GetStockByIdAsync(int id);
        Task<Stock> CreateStockAsync(Stock stock);
        void UpdateStock(Stock stock);
        Task<bool> DeleteStockAsync(int id);
    }

}
