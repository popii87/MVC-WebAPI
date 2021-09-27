using Movies.DAL.Models.Data;
using Movies.DAL.Models.Dto;
using Movies.DAL.Repositories.Interfaces;
using Movies.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DAL.Services.Classes
{
    public class UserService : IUser
    {
        private readonly IRepository<User> _userRepo;
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public string CreateNewUser(UserDto user)
        {
            var newUser = Mappers.UserDtoToUser(user);
            _userRepo.Create(newUser);
            return "New User created!!!";
        }
        public string DeleteUser(int id)
        {
            _userRepo.Delete(id);
            return "User deleted";
        }
        public List<UserDto> GetAll()
        {

            var users = _userRepo.GetAll().Select(u => Mappers.UserToUserDto(u)).ToList();
            return users;
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.Id == id);
            return Mappers.UserToUserDto(user);

        }
       
        public string UpdateUser(UserDto user)
        {
            var updatedUser = Mappers.UserDtoToUser(user);
            _userRepo.Update(updatedUser);
            return "User is updated";
        }
    }
}
