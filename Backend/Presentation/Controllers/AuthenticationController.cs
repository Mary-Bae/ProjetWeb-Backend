using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationServices _authenticationService;
        
        public AuthenticationController(ILogger<AuthenticationController> logger,
                                        IAuthenticationServices authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register(string login, string password, int roleId)
        {
            try
            {
                _authenticationService.RegisterUser(login, password, roleId);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public object Login(string login, string password)
        {
            return _authenticationService.Login(login, password);
        }

        [HttpGet("Refreshtoken")]
        [AllowAnonymous]
        public IActionResult Refreshtoken(string token)
        {
            try
            {
                var refreshedToken = _authenticationService.RefreshToken(token);
                return Ok(new { Token = refreshedToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "admin")]
        public IActionResult AssignRole(string username, string roleName)
        {
            try
            {
                _authenticationService.AssignRole(username, roleName);
                return Ok("Role assigned successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}
