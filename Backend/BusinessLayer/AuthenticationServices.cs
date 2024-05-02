using DataAccessLayer;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _config;

        public AuthenticationServices(IUserRepository userRepository, IConfiguration config, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _config = config;
        }

        public void RegisterUser(string username, string password, int roleId)
        {
            var existingUser = _userRepository.FindUserByUsername(username);
            if (existingUser != null)
                throw new Exception("User already exists");

            var salt = DateTime.Now.ToString("dddd"); // get the day of week. Ex: Sunday
            var passwordHash = HashPassword(password, salt);
            var newUser = new User { Username = username, Password = passwordHash, Salt = salt, RoleId = roleId };
            _userRepository.AddUser(newUser);
        }

        public object Login(string username, string password)
        {
            var user = _userRepository.FindUserByUsername(username.ToLower());
            if (user == null)
            {
                throw new Exception("Login failed; Invalid userID");
            }

            var passwordHash = HashPassword(password, user.Salt);
            if (user.Password == passwordHash)
            {
                var token = GenerateJSONWebToken(user);
                return new { token };
            }
            throw new Exception("Login failed; Invalid userID or password");

        }

        public string RefreshToken(string token)
        {
            var (principal, jwtToken) = DecodeJwtToken(token);
            if (jwtToken == null)
            {
                throw new SecurityTokenException("Invalid token");
            }
            var userName = jwtToken.Subject;
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("User not found");
            }
            var user = _userRepository.FindUserByUsername(userName.ToLower());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return GenerateJSONWebToken(user);
        }

        public string GenerateJSONWebToken(User user)
        {
            var secretKey = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Username));

            if (user.Role != null)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName));
            }
            else
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Guest"));
            }

            claimsIdentity.AddClaim(new Claim("custom_info", "info"));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); ;

            var jwtIssuer = _config["Jwt:Issuer"];
            var jwtAudience = _config["Jwt:Audience"];

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(string password, string salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                       password: Encoding.UTF8.GetBytes(password),
                       salt: Encoding.UTF8.GetBytes(salt),
                       iterations: 10,
                       hashAlgorithm: HashAlgorithmName.SHA512,
                       outputLength: 10);
            return Convert.ToHexString(hash);
        }

        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            JwtSecurityTokenHandler handler = null;
            ClaimsPrincipal principal = null;
            SecurityToken validatedToken = null;

            try
            {
                handler = new JwtSecurityTokenHandler();
                principal = handler
                .ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidIssuer = _config["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                        ValidAudience = _config["Jwt:Audience"],
                    },
                    out validatedToken);
            }
            catch (SecurityTokenExpiredException ex)
            {
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token) as JwtSecurityToken;
                return (principal, jwtToken);
            }
            throw new SecurityTokenException("Invalid token");
        }

        public void AssignRole(string username, string roleName)
        {
            var user = _userRepository.FindUserByUsername(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var role = _roleRepository.FindRoleByName(roleName);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            user.RoleId = role.Id; 
            _userRepository.UpdateUser(user); 
        }
    }
}
