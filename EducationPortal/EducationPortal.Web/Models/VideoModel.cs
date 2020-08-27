using EducationPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.WEB.Models.ViewModel
{
    public class VideoModel : MaterialModel
    {
        [DisplayName("Продолжительность")]
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Duration { get; set; }

        [DisplayName("Разрешение")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(12)]
        public string Quality { get; set; }
    }
}