using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Interfaces
{
    public interface ISkill
    {
        int CreateSkill(Skill skill);
    }
}
