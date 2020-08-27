using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.Web.Models
{
    public class MaterialModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Name { get; set; }
    }
}