using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationPortal.Web.Models
{
    public class CourseBaseInfoModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CountOfMaterials { get; set; }

        public int CountOfSubs {get; set; }
    }
}