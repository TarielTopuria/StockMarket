using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocksAsync();
        Task<Stock> GetStockByIdAsync(int id);
    }
}
