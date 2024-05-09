using BusinessLayer;
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
    }
}

