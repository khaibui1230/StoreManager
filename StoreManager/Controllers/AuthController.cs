using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            if (userLogin.Username == "admin" && userLogin.Password == "password") // Thay bằng kiểm tra DB
            {
                var token = _authService.GenerateJwtToken(userLogin);
                return Ok(new { token });
            }

            return Unauthorized(new { message = "Invalid credentials" });
        }
    }
}
