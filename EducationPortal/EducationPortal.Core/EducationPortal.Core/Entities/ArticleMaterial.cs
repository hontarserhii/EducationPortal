using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class ArticleMaterial : BaseMaterial
    {
        public DateTime Published { get; set; }

        public string Link { get; set; }
    }
}
