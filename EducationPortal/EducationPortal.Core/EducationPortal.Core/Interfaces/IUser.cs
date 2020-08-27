using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core
{
    public interface IUser
    {
        User GetUserInfo(int id);

        bool Registrate(User userDTO);

        int Authorizate(string login, string password);
    }
}
