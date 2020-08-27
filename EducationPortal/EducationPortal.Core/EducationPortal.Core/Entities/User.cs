using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
     
        public int? RoleId { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<UserCourses> UserCourses { get; set; }

        public virtual ICollection<UserBaseMaterials> UserMaterials { get; set; }

        public virtual ICollection<UserSkills> UserSkills { get; set; }
    }
}
