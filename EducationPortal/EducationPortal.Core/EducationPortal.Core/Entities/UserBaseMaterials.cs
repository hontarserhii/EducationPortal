using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class UserBaseMaterials : BaseEntity
    {
        public int? UserId { get; set; }

        public int? BaseMaterialId { get; set; }

        public bool IsFinished { get; set; }

        public User User { get; set; }

        public BaseMaterial BaseMaterial { get; set; }
    }
}
