using DataAccessLayer;
using Domain;
using ExceptionList;
using Models;

namespace BusinessLayer
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        public CourseService(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
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
            var user = _userRepository.GetUserById(courseDto.UserId);
            if (user == null || user.RoleId != 2)
            {
                throw new ListOfExceptions(ErreurCodeEnum.InstructorOnly);
            }
            var course = new Course
            {
                Name = courseDto.Name,
                LevelName = courseDto.LevelName,
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
            var user = _userRepository.GetUserById(courseDto.UserId);

            if (course == null)
            {
                throw new ListOfExceptions(ErreurCodeEnum.CourseNotFound);
            }     
            if (user == null || user.RoleId != 2)
            {
                throw new ListOfExceptions(ErreurCodeEnum.InstructorOnly);
            }

            course.Name = courseDto.Name;
            course.LevelName = courseDto.LevelName;
            course.Schedule = courseDto.Schedule;
            course.UserId = courseDto.UserId;
            course.Description = courseDto.Description;

            _courseRepository.UpdateCourse(course);
        }

        public List<CourseDTO> GetCoursesByTeacherId(int Id)
        {
            return _courseRepository.GetCoursesByTeacherId(Id);
        }



    }


}