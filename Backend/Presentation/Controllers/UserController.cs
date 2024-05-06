﻿using BusinessLayer;
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
        [Authorize(Roles = "admin")]
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
    }
}
