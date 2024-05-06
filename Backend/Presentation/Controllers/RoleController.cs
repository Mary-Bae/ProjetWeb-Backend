using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize(Roles = "student, admin, instructor")]
        public ActionResult<IEnumerable<RoleDTO>> GetRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }
    }
}
