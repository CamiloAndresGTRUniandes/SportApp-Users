using Microsoft.AspNetCore.Mvc;
using Users.Aplication.Contracts.Identity;
using Users.Aplication.Models.Identity;

namespace Users.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class AccountController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest authRequest)
        => Ok(await _authService.Login(authRequest)); 
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegistrationRequest registrationRequest)
        => Ok(await _authService.Register(registrationRequest));

        [HttpGet("is-email-unique/{email}")]
        public async Task<ActionResult<bool>> IsEmailUnique(string  email)
        =>  Ok(await _authService.IsEmailUnique(email));

    }
}
