using BusinessLayer;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
