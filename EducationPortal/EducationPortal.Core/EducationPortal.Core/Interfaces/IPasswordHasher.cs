using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
