using EducationPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.WEB.Models.ViewModel
{
    public class ArticleModel : MaterialModel
    {
        [DisplayName("Дата публикации")]
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Published { get; set; } = DateTime.Today;

        [DisplayName("Ссылка на источник")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(50)]
        public string Link { get; set; }
    }
}