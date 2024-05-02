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
        [Authorize(Roles = "admin, instructor")]
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
                return Ok("Course added successfully.");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Failed to add course: " + ex.Message);
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
                return Ok("Course deleted successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound("Course not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, instructor")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseUpdateDTO updatedCourseDto)
        {
            try
            {
                _courseService.UpdateCourse(id, updatedCourseDto);
                return Ok("Course updated successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound("Course not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

    }
}