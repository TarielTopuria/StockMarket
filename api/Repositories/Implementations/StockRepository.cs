using api.Data;
using api.Helpers;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations
{
    public class StockRepository(AppDbContext context) : Repository<Stock>(context), IStockRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Stock>?> GetStocksAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            
            if(stocks is null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var stocksList = await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
            return stocksList;
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            var stocks = await _context.Stocks.Include(c => c.Comments).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (stocks is null)
            {
                return null;
            }
            return stocks;
        }

        public async Task<Stock> CreateStockAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            return stock;
        }

        public void UpdateStock(Stock stock)
        {
            _context.Stocks.Update(stock);
        }

        public async Task<bool> DeleteStockAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return false;
            }

            _context.Stocks.Remove(stock);
            return true;
        }
    }
}
