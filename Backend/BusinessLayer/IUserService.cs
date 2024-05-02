using Domain;
using Models;

namespace BusinessLayer
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
    }
}