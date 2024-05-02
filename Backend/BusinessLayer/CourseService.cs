using DataAccessLayer;
using Domain;
using Models;

namespace BusinessLayer
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<CourseDTO> GetAll()
        {
            return _courseRepository.GetAll();
        }
        public CourseDTO? Get(int id)
        {
            return _courseRepository.Get(id);
        }
        public void AddCourse(CourseCreateDTO courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                LevelId = courseDto.LevelId,
                Schedule = courseDto.Schedule,
                UserId = courseDto.UserId,
                Description = courseDto.Description
            };

            _courseRepository.AddCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id);
        }
        public void UpdateCourse(int id, CourseUpdateDTO courseDto)
        {
            var course = _courseRepository.GetCourseForUpdate(id);
            if (course == null)
            {
                throw new InvalidOperationException("Course not found");
            }

            course.Name = courseDto.Name;
            course.LevelId = courseDto.LevelId;
            course.Schedule = courseDto.Schedule;
            course.UserId = courseDto.UserId;
            course.Description = courseDto.Description;

            _courseRepository.UpdateCourse(course);
        }
    }


}