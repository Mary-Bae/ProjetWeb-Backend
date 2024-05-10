using Domain;
using Models;

namespace BusinessLayer
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<StudentGradeDTO> GetStudentsGrades();
        IEnumerable<UserDTO> GetUsersByRole(string roleName);
        void DeleteUser(int id);
        UserDTO? GetUserById(int id);
        UserDTO GetUserByUsername(string username);
    }
}