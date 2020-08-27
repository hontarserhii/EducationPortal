using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public abstract class BaseMaterial : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<CourseBaseMaterials> CourseBaseMaterials { get; set; }

        public virtual ICollection<UserBaseMaterials> UserBaseMaterials { get; set; }

        public ArticleMaterial ArticleMaterial { get; set; }

        public BookMaterial BookMaterial { get; set; }

        public VideoMaterial VideoMaterial { get; set; }
    }
}
