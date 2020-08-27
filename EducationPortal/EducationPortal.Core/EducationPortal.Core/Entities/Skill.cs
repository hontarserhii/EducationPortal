using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserSkills> UserSkills{ get; set; }

        public virtual ICollection<CourseSkills> CourseSkills { get; set; }
    }
}
