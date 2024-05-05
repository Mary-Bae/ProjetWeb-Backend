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
            var users = _userRepository.GetAllUsers();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                //RoleId = user.RoleId,
                RoleName = user.RoleName

            }).ToList();
        }

        public bool IsInstructor(int userId)
        {
            var user = _userRepository.FindUserByUserId(userId);
            return user != null && user.RoleId == 2;
        }
    }
}
