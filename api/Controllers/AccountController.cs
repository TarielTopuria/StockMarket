using api.DTOs.Account;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IAccountService accountService) : Controller
    {
        private readonly IAccountService accountService = accountService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await accountService.RegisterUserAsync(register);

                if (result.Succeeded)
                    return Ok($"User {register.Username} has been created");
                else
                    return StatusCode(500, result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
