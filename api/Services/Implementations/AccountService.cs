using api.DTOs.Account;
using api.Models;
using api.Services.Interfaces;
using api.UOW.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace api.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;

        public AccountService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDTO registerDto)
        {
            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var createUser = await userManager.CreateAsync(appUser, registerDto.Password);

            if (createUser.Succeeded)
            {
                await userManager.AddToRoleAsync(appUser, "Client");
                await unitOfWork.CommitAsync(); // Save changes using Unit of Work
            }

            return createUser;
        }
    }


}
