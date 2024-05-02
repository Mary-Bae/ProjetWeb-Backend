using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;
        public CourseRepository(CourseDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _context.Courses
            .Include(c => c.Level)
            .Include(c => c.User)
            .Select(c => new CourseDTO
        {
            Name = c.Name,
            LevelName = c.Level.LevelName,
            Schedule = c.Schedule,
            Username = c.User.Username,
            Description = c.Description
        })
        .ToList();
        }
        public CourseDTO? Get(int id)
        {
            return _context.Courses
                .Where(c => c.Id == id)
                .Include(c => c.Level)
                .Include(c => c.User)
                .Select(c => new CourseDTO
                {
                    Name = c.Name,
                    LevelName = c.Level.LevelName,
                    Schedule = c.Schedule,
                    Username = c.User.Username,
                    Description = c.Description
                })
                .FirstOrDefault();
        }

        public Course? GetCourseForUpdate(int id)
        {
            return _context.Courses
                           .Include(c => c.Level)
                           .Include(c => c.User)
                           .FirstOrDefault(c => c.Id == id);
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Course not found");
            }
        }
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

    }
}