using api.Data;
using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories.Implementations
{
    public class AccountRepository(AppDbContext context) : Repository<AppUser>(context), IAccountRepository
    {
        // Implement additional methods defined in IAccountRepository
    }
}
