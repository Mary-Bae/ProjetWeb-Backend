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

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
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
