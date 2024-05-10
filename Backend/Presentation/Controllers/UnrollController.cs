using BusinessLayer;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class UnrollController : Controller
    {
        private readonly IUnrollService _unrollService;
        public UnrollController(IUnrollService unrollService)
        {
            _unrollService = unrollService;
        }
        
        [HttpGet("GetUnrollByUser/{userId}")]
        [Authorize(Roles = "admin, instructor, student")]
        public ActionResult <List<CourseStudentDTO>> GetUnrollByUser(int userId)
        {
            var user = _unrollService.GetCoursesByStudent(userId);
            if (user == null)
            {
                return NotFound();
            }
                return Ok(user);
        }

        [HttpPost()]
        [Authorize(Roles = "admin, instructor, student")]
        public IActionResult AddUnrollement(int userId, int courseId)
        {
            try
            {
                _unrollService.AddUnrollement(userId, courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete()]
        [Authorize(Roles = "admin, instructor, student")]
        public ActionResult DelUnrollement(int userId, int courseId)
        {
            try
            {
                _unrollService.DelUnrollement(userId, courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("StudentsByCourse/{courseId}")]
        [Authorize(Roles = "instructor, admin")]
        public ActionResult<List<CourseStudentDTO>> GetStudentsByCourse(int courseId)
        {
            var students = _unrollService.GetStudentByCourse(courseId);
            
            if (students == null)
            {
                return NotFound();
            }
                return Ok(students);
        }
    }
}


