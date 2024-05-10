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

        [HttpGet("grades")]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<IEnumerable<StudentGradeDTO>> GetStudentGrades()
        {
            try
            {
                var studentGrades = _userService.GetStudentsGrades();
                return Ok(studentGrades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ByRole/{roleName}")]
        [Authorize(Roles = "admin, instructor")]
        public ActionResult<IEnumerable<UserDTO>> GetUsersByRole(string roleName)
        {
            var users = _userService.GetUsersByRole(roleName);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            } 
        }

        [HttpGet("ById")]
        [Authorize(Roles = "admin, instructor")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("ByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                var userDto = _userService.GetUserByUsername(username);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
