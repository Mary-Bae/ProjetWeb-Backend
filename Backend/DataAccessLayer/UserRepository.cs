using Domain;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _context;

        public UserRepository(CourseDbContext context)
        {
            _context = context;
        }
        public IEnumerable<UserDTO> GetAllUsers()
        {
                return _context.Users
                .Include(c => c.Role)
                .Select(c => new UserDTO
                {
                    Id = c.Id,
                    Username = c.Username,
                    RoleName = c.Role.RoleName,
                })
            .ToList();
        }
        public User? FindUserByUsername(string username)
        {
            return _context.Users.Include(u => u.Role)
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

        }

        public User? FindUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
