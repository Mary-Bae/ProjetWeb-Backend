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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<IEnumerable<CourseDTO>> GetCourses()
        {
            try
            {
                var courses = _courseService.GetAll();
                return Ok(courses);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("ById")]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<CourseDTO> Get(int id)
        {
            var course = _courseService.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        [Authorize(Roles = "admin, instructor")]
        public IActionResult PostCourse([FromBody] CourseCreateDTO courseDto)
        {
            try
            {
                _courseService.AddCourse(courseDto);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, instructor")]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                _courseService.DeleteCourse(id);
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

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, instructor")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseUpdateDTO updatedCourseDto)
        {
            try
            {
                _courseService.UpdateCourse(id, updatedCourseDto);
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

        [HttpGet("ByTeacher/{Id}")]
        [Authorize(Roles = "instructor")]
        public ActionResult<List<CourseDTO>> GetCoursesByInstructor(int Id)
        {
            var courses = _courseService.GetCoursesByTeacherId(Id);
            if (courses == null || courses.Count == 0)
            {
                return NotFound();
            }
            return Ok(courses);
        }

    }
}