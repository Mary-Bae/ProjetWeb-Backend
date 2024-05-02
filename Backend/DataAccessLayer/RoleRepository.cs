using Domain;
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

        public Role FindRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
        }
    }
}
