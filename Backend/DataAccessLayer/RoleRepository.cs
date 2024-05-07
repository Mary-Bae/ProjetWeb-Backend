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
    public class RoleRepository : IRoleRepository
    {
        private readonly CourseDbContext _context;

        public RoleRepository(CourseDbContext context)
        {
            _context = context;
        }

        public Role FindRoleById(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == roleId);
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return _context.Roles
            .Select(r => new RoleDTO
            {
                Id = r.Id,
                RoleName = r.RoleName
            })
        .ToList();
        }
    }
}
