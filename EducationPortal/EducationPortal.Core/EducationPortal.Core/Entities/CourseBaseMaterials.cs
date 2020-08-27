using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class CourseBaseMaterials : BaseEntity
    {
        public int? CourseId { get; set; }

        public int? BaseMaterialId { get; set; }

        public Course Course { get; set; }

        public BaseMaterial BaseMaterial { get; set; }
    }
}
