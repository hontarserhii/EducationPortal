using EducationPortal.Core;
using EducationPortal.Core.Entities;
using EducationPortal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BL.Services.SkillService
{
    public class SkillService : ISkill
    {
        private readonly IEFRepository repository;

        public SkillService(IEFRepository repository)
        {
            this.repository = repository;
        }

        public int CreateSkill(Skill skill)
        {
            int id = this.repository.Create<Skill>(new Skill
            {
                Name = skill.Name,
            });
            return id;
        }
    }
}