using DataAccessLayer;
using Domain;
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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
