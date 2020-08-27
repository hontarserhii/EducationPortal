using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class BookMaterial : BaseMaterial
    {
        public string Author { get; set; }

        public int Page { get; set; }

        public string Format { get; set; }

        public DateTime Issued { get; set; }

        public BaseMaterial BaseMaterial { get; set; }
    }
}
