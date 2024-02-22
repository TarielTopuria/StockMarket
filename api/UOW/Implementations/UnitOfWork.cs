using api.Data;
using api.Repositories.Implementations;
using api.Repositories.Interfaces;
using api.UOW.Interfaces;
using AutoMapper;

namespace api.UOW.Implementations
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private IAccountRepository _accounts;
        private IStockRepository _stocks;

        public IAccountRepository Accounts
        {
            get
            {
                return _accounts ??= new AccountRepository(_context);
            }
        }
        public IStockRepository Stocks => _stocks ??= new StockRepository(_context);


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
