using api.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace api.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterDTO registerDto);
        // Other account-related methods
    }
}
