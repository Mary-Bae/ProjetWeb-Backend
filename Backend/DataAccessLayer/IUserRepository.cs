using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetAllUsers();

        IEnumerable<StudentGradeDTO> GetStudentsGrades();
        IEnumerable<UserDTO> GetUsersByRole(string roleName);
        User? FindUserByUsername(string username);
        //User? FindUserByUserId(int userId);
        UserDTO? GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
