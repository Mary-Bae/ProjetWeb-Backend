﻿using Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRoleRepository
    {
        Role FindRoleByName(string roleName);
        IEnumerable<RoleDTO> GetAllRoles();
    }
}
