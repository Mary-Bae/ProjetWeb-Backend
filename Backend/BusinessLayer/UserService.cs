using DataAccessLayer;
using Domain;
using ExceptionList;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnrollRepository _unrollRepository;
        private readonly IGradeRepository _gradeRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository,
            ICourseRepository courseRepository, IUnrollRepository unrollRepository, IGradeRepository gradeRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _courseRepository = courseRepository;
            _unrollRepository = unrollRepository;
            _gradeRepository = gradeRepository;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IEnumerable<UserDTO> GetUsersByRole(string roleName)
        {
            return _userRepository.GetUsersByRole(roleName);
        }

        public IEnumerable<StudentGradeDTO> GetStudentsGrades()
        {
            return _userRepository.GetStudentsGrades();
        }

        public void DeleteUser(int userId)
        {
            //L'utilisateur doit exister
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new ListOfExceptions(ErreurCodeEnum.UserNotFound);
            }
            //Si c'est un instructeur qui donne cours, il doit d'abord se désinscrire du cours qu'il enseigne
            var isTeacherinCourse = _courseRepository.IsTeacherInCourse(userId);
            if (isTeacherinCourse)
            {
                throw new ListOfExceptions(ErreurCodeEnum.TeacherInCourse);
            }
            // Si c'est un étudiant, son delete entrainera le delete de ses enrollements
            var unrolls = _unrollRepository.GetCoursesByStudent(userId);
            if (unrolls.Any())
            {
                foreach (var unroll in unrolls)
                {
                    _unrollRepository.DelUnrollement(unroll.UserId, unroll.CourseId);
                }
            }
            //Si c'est un étudiant, le delete entrainera aussi le delete de son grade
            var grade = _gradeRepository.GetGradeByStudent(userId);
            if (grade != null)
            {
                _gradeRepository.DelGradeStudent(userId);
            }

            _userRepository.DeleteUser(userId);
        }
        public UserDTO? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public UserDTO GetUserByUsername(string username)
        {
            var user = _userRepository.FindUserByUsername(username);
            if (user == null)
            {
                throw new ListOfExceptions(ErreurCodeEnum.UserNotFound);
            }

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                RoleId = user.Role.Id,
                RoleName = user.Role.RoleName
            };
        }
    }
}
