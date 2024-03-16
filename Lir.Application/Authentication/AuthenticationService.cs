using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Lir.Application.Authentication.ImputTypes;
using Lir.Application.Authentication.Payload;
using Lir.Core.Interfaces;
using Lir.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lir.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IUserRolesService _userRolesService;
        private readonly TokenSettings _tokenSettings;

        public AuthenticationService(IUserService userService, IUserRolesService userRolesService, IOptions<TokenSettings> tokenSettings)
        {
            _userRolesService = userRolesService;
            _tokenSettings = tokenSettings.Value;
            _userService = userService;
        }

        public async Task<LoginUserPayload> Login(LoginInputType loginInput)
        {
            var payload = new LoginUserPayload();

            if (string.IsNullOrEmpty(loginInput.Email)
                || string.IsNullOrEmpty(loginInput.Password))
            {
                payload.Message = "Invalid Credentials";
            }

            var user = await _userService.GetUserByEmailAsync(loginInput.Email);
            if (user == null)
            {
                payload.Message = "Invalid Credentials";
            }

            if (user != null && ValidatePasswordHash(loginInput.Password, user.PasswordHash))
            {
                var roles = await _userRolesService.GetByUserId(user.Id);
                payload.User = user;
                payload.AccessToken = GenerateAccessToken(user.Id.ToString(), user.Email, roles.Select(r => r.Name));
                payload.RefreshToken = GenerateRefreshToken(user.Id.ToString(), user.Email);
                payload.Message = "Login success";
            }
            else
            {
                payload.Message = "Invalid credentials";
            }

            return payload;
        }

        public async Task<RegisterUserPayload> Register(RegisterInputType registerInput)
        {
            var payload = new RegisterUserPayload();
            string errorMessage = await RegistrationValidations(registerInput);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                payload.Message = errorMessage;
                return payload;
            }

            var newUser = new User
            {
                Email = registerInput.Email,
                Name = registerInput.Name,
                Bio = registerInput.Bio,
                Username = registerInput.Username,
                PasswordHash = PasswordHash(registerInput.ConfirmPassword)
            };

            await _userService.AddAsync(newUser);

            var roles = new List<UserRoles>() { new UserRoles() { Name = "user" } };
            var accessToken = GenerateAccessToken(newUser.Id.ToString(), newUser.Email, roles.Select(r => r.Name).ToList<string>());

            var refreshToken = GenerateRefreshToken(newUser.Id.ToString(), newUser.Email);

            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenExpiration = DateTime.UtcNow.AddDays(_tokenSettings.RefreshTokenExpirationDays);
            await _userService.UpdateAsync(newUser.Id, newUser);

            payload.User = newUser;
            payload.AccessToken = accessToken;
            payload.RefreshToken = refreshToken;
            payload.Message = "Registration success";

            return payload;
        }

        private string GenerateAccessToken(string userId, string email, IEnumerable<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, email)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _tokenSettings.Issuer,
                _tokenSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken(string userId, string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Email, email)
            };

            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_tokenSettings.RefreshTokenExpirationDays),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> RegistrationValidations(RegisterInputType registerInput)
        {
            var user = await _userService.GetUserByEmailAsync(registerInput.Email);
            if (user != null)
            {
                return "Email is already in use";
            }

            user = await _userService.GetUserByUsernameAsync(registerInput.Username);
            if (user != null)
            {
                return "Username is already in use";

            }
            if (string.IsNullOrEmpty(registerInput.Email))
            {
                return "Email can't be empty";
            }

            if (string.IsNullOrEmpty(registerInput.Password)
                || string.IsNullOrEmpty(registerInput.ConfirmPassword))
            {
                return "Password Or ConfirmPassword Can't be empty";
            }

            if (registerInput.Password != registerInput.ConfirmPassword)
            {
                return "Invalid confirm password";
            }

            string emailRules = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            if (!Regex.IsMatch((string)registerInput.Email, emailRules))
            {
                return "Not a valid email";
            }

            string passwordRules = @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";
            if (!Regex.IsMatch((string)registerInput.Password, passwordRules))
            {
                return "Not a valid password";
            }

            return string.Empty;
        }

        private string PasswordHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        private bool ValidatePasswordHash(string password, string dbPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(dbPassword);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
