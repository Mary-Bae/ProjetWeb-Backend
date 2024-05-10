using Domain;
using ExceptionList;
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

        public void AddUnrollement(int userId, int courseId)
        {
            if (!_context.CourseStudents.Any(cs => cs.UserId == userId && cs.CourseId == courseId))
            {
                _context.CourseStudents.Add(new CourseStudent { UserId = userId, CourseId = courseId });
                _context.SaveChanges();
            }
            else
            {
                throw new ListOfExceptions(ErreurCodeEnum.UnrollExists);
            }
        }

        public void DelUnrollement(int userId, int courseId)
        {
            var unroll = _context.CourseStudents.FirstOrDefault(cs => cs.UserId == userId && cs.CourseId == courseId);
            if (unroll != null)
            {
                _context.CourseStudents.Remove(unroll);
                _context.SaveChanges();
            }
            else
            {
                throw new ListOfExceptions(ErreurCodeEnum.UnrollNotFound);
            }
        }


        public List<CourseStudentWithNameDTO> GetStudentsByCourse(int courseId)
        {
            return _context.CourseStudents
                           .Where(cs => cs.CourseId == courseId)
                           .Select(cs => new CourseStudentWithNameDTO
                           {
                               UserId = cs.UserId,
                               CourseId = cs.CourseId,
                               Username = cs.User.Username,
                               CourseName = cs.Course.Name
                           })
                           .ToList();
        }
    }
}
