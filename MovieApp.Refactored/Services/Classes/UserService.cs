using Common.Exceptions;
using DataAccess.Repositories.Interfaces;
using DomainModels.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RequestModels;
using Services.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IOptions<DatabaseOptions> _options;
        public UserService(IRepository<User> userRepository, IOptions<DatabaseOptions> options)
        {
            _userRepository = userRepository;
            _options = options;
        }
        public UserModel Authenticate(LoginRequestModel requestModel)
        {
            var hashedPassword = HashedString(requestModel.Password);
            var user = _userRepository.GetAll().SingleOrDefault(x => x.Username == requestModel.Username && x.Password == hashedPassword);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
            return userModel;
        }

        public void Register(RegisterRequestModel requestModel)
        {
            if (requestModel.Password != requestModel.ConfirmPassword)
            {
                throw new UserException("Password did not match");
            }
            var hashedPassword = HashedString(requestModel.Password);
            var user = new User()
            {
                Username = requestModel.UserName,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Password = hashedPassword,
                FavoriteGenre = requestModel.FavoriteGenre

            };
            _userRepository.Add(user);
        }

        private string HashedString(string input)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return Encoding.ASCII.GetString(md5Data);
        }
    }
}
