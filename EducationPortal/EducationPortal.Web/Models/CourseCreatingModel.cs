using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Web.Models
{
    public class CourseCreatingModel
    {
        [DisplayName("Название курса")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Описание курса")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }
    }
}