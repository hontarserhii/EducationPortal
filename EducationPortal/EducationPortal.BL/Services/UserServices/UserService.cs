using EducationPortal.Core;
using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BL.Services.UserServices
{
    public class UserService : IUser
    {
        private readonly IEFRepository repository;
        private IPasswordHasher passwordHasher;

        public UserService(IEFRepository repository, IPasswordHasher passwordHasher)
        {
            this.repository = repository;
            this.passwordHasher = passwordHasher;
        }

        public int Authorizate(string login, string password)
        {
            string pass = passwordHasher.HashPassword(password);
            User gettedUser = this.repository.FirstOrDefault<User>(user => user.Login == login && user.Password == pass);
            if (gettedUser != null) 
                return gettedUser.Id;
            else
                return -1;
        }

        public bool Registrate(User user)
        {
            if (this.repository.FirstOrDefault<User>(u => u.Login == user.Login) == null)
            {
                Role role = this.repository.FirstOrDefault<Role>(r => r.Id == 2);
                if (role != null)
                {
                    this.repository.Create<User>(new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Login = user.Login,
                        Age = user.Age,
                        Password = passwordHasher.HashPassword(user.Password),
                        Role = role
                    });

                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public User GetUserInfo(int id)
        {
            return repository.FirstOrDefault<User>(user => user.Id == id);
        }

    }
}
