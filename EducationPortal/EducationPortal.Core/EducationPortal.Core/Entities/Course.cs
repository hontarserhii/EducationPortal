using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Name{ get; set; }

        public string Description { get; set; }

        public virtual ICollection<CourseSkills> CourseSkills { get; set; }

        public virtual ICollection<UserCourses> UserCourses { get; set; }

        public virtual ICollection<CourseBaseMaterials> CourseBaseMaterials { get; set; }
    }
}
