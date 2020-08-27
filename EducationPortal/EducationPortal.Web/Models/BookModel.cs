using EducationPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.WEB.Models.ViewModel
{
    public class BookModel : MaterialModel
    {
        [DisplayName("Автор")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(500)]
        public string Author { get; set; }

        [DisplayName("Количество страниц")]
        [DataType(DataType.Text)]
        [Required]
        public int Page { get; set; }

        [DisplayName("Формат")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(50)]
        public string Format { get; set; }

        [DisplayName("Год выпуска")]
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Issued { get; set; }

    }
}