using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnrollRepository : IUnrollRepository
    {
        private readonly CourseDbContext _context;
        public UnrollRepository(CourseDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<CourseStudentDTO> GetCoursesByStudent(int id)
        {
            var courses = _context.CourseStudents
                            .Where(cs => cs.UserId == id)
                            .Select(cs => new CourseStudentDTO
                            {
                                UserId = cs.UserId,
                                CourseId = cs.CourseId
                            }).ToList();

            return courses;
        }
    }
}
