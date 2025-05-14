using HotelListing.API.Contracts;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] ApiUserDTO apiUserDTO)
        {
            var errors = await _authManager.Register(apiUserDTO);

            if (errors.Any())
            {
                foreach(var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok(new { Message = "User registered successfully" });

        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginDTO logInUserDTO)
        {
            var authResponse = await _authManager.Login(logInUserDTO);

            if (authResponse == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            return Ok(new { Message = "User logged in successfully" });

        }

        [HttpPost("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDTO request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            return Ok(new { Message = "User logged in successfully" });

        }
    }
}
