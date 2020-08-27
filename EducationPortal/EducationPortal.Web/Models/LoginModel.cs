using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.Web.Models
{
    public class LoginModel
    {
        [DisplayName("Логин")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}