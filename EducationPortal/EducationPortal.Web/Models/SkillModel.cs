using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.WEB.Models.ViewModel
{
    public class SkillModel
    {
        [DisplayName("Название")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string SkillName { get; set; }
    }
}