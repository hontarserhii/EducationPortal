using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class UserSkills : BaseEntity
    {
        public int? UserId { get; set; }

        public int? SkillId { get; set; }

        public double Rate { get; set; }

        public User User { get; set; }

        public Skill Skill { get; set; }
    }
}
