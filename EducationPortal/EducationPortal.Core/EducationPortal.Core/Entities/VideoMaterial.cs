using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class VideoMaterial : BaseMaterial
    {
        public DateTime Duration { get; set; }

        public string Quality { get; set; }

        public BaseMaterial BaseMaterial { get; set; }
    }
}
