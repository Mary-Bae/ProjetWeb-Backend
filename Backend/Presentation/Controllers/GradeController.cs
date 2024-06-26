﻿using BusinessLayer;
using ExceptionList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [HttpGet]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<IEnumerable<GradeDTO>> GetGrades()
        {
            var grades = _gradeService.GetAllGrades();
            return Ok(grades);
        }

        [HttpGet("GetGradeByUser/{userId}")]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<StudentGradeDTO> GetGradeByUser(int userId)
        {
            var user = _gradeService.GetGradeByStudent(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Authorize(Roles = "admin, instructor")]
        public IActionResult UpdGradeStudent(int userId, int gradeId)
        {
            try
            {
                _gradeService.UpdateGradeStudent(userId, gradeId);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
