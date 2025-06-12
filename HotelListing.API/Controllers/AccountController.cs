using HotelListing.API.Core.Contracts;
using HotelListing.API.Core.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthManager authManager, ILogger<AccountController> logger)
        {
            this._authManager = authManager;
            this._logger = logger;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] ApiUserDTO apiUserDTO)
        {
            _logger.LogInformation($"Registration attempt for {apiUserDTO.Email} started at {DateTime.UtcNow}");

            try
            {
                var errors = await _authManager.Register(apiUserDTO);

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                return Ok(new { Message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(Register)} action {ex.Message} - User registration" +
                    $" attmpet for {apiUserDTO.Email}");
                return Problem($"Something went wrong in the {nameof(Register)}. Please contact support", statusCode: 500);
            }

            

        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginDTO logInUserDTO)
        {
            _logger.LogInformation($"Login attempt for {logInUserDTO.Email} started at {DateTime.UtcNow}");

            try
            {
                var authResponse = await _authManager.Login(logInUserDTO);

                if (authResponse == null)
                {
                    return Unauthorized(new { Message = "Invalid credentials" });
                }

                return Ok(new { Message = "User logged in successfully" });
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong in the {nameof(Login)} action {ex.Message} - User login" +
                    $" attmpet for {logInUserDTO.Email}");
                return Problem($"Something went wrong in the {nameof(Login)}. Please contact support", statusCode: 500);
            }
            

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
