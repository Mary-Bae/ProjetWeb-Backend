using BusinessLayer;
using ExceptionList;
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
        public IActionResult Register(string login, string password)
        {
            try
            {
                _authenticationService.RegisterUser(login, password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public object Login(string login, string password)
        {
            try
            {
                return _authenticationService.Login(login, password);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "admin")]
        public IActionResult AssignRole(string username, int roleId)
        {
            try
            {
                _authenticationService.AssignRole(username, roleId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }



}
