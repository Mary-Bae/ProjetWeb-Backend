using Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAuthenticationServices
    {
        void RegisterUser(string username, string password, int roleId);
        object Login(string username, string password);
        string RefreshToken(string token);
        string GenerateJSONWebToken(User user);
        string HashPassword(string password, string salt);
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);

        void AssignRole(string username, string roleName);
    }
}
