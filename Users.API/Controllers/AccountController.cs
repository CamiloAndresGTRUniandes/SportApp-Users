namespace Users.API.Controllers ;
using Aplication.Contracts.Identity;
using Aplication.Models.Identity;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    public class AccountController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest authRequest)
        {
            return Ok(await _authService.Login(authRequest));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegistrationRequest registrationRequest)
        {
            return Ok(await _authService.Register(registrationRequest));
        }

        [HttpGet("is-email-unique/{email}")]
        public async Task<ActionResult<bool>> IsEmailUnique(string email)
        {
            return Ok(await _authService.IsEmailUnique(email));
        }
    }
