using Domain;
using ExceptionList;
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

        public IEnumerable<StudentGradeDTO> GetStudentsGrades()
        {
            // Jointure externe entre Users et GradeStudents
            var students = from u in _context.Users
                           join gs in _context.GradeStudents on u.Id equals gs.UserId into grades
                           from g in grades.DefaultIfEmpty()  // Tous les étudiants sont inclus même ceux sans grade
                           where u.Role.RoleName == "student"
                           select new StudentGradeDTO
                           {
                              UserId = u.Id,
                              Username = u.Username,
                              GradeName = g.Grade != null ? g.Grade.GradeName : null

                           };

            return students.ToList();
        }

        public IEnumerable<UserDTO> GetUsersByRole(string roleName)
        {
            return _context.Users
                .Where(u => u.Role.RoleName == roleName)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username
                })
        .ToList();
        }

        public User? FindUserByUsername(string username)
        {
            return _context.Users.Include(u => u.Role)
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }

        public UserDTO? GetUserById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Role)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    RoleId = u.RoleId,
                    RoleName = u.Role.RoleName
                })
                .FirstOrDefault();
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
            else
            {
                throw new ListOfExceptions(ErreurCodeEnum.UserNotFound);
            }
        }
    }
}
