using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;
        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetStocksAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            var result = await _context.Stocks.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
