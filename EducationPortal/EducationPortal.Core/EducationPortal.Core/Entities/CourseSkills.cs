using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class CourseSkills : BaseEntity
    {
        public int? CourseId { get; set; }

        public int? SkillId { get; set; }

        public double Rate { get; set; }

        public Course Course { get; set; }

        public Skill Skill { get; set; }
    }
}
