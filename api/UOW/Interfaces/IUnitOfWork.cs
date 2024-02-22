using api.Repositories.Interfaces;

namespace api.UOW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IStockRepository Stocks { get; }
        Task CommitAsync();
    }
}
