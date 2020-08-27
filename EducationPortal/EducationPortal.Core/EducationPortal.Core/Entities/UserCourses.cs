using EducationPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Core.Entities
{
    public class UserCourses : BaseEntity
    {
        public int? UserId { get; set; }

        public int? CourseId { get; set; }

        public DateTime BeginningDate { get; set; }

        public string Status { get; set; }

        public User User { get; set; }

        public Course Course { get; set; }
    }
}
