using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationPortal.Web.Models
{
    public class RegisterModel
    {
        [Display(Name = "Имя")]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name = "Возраст")]
        [Required]
        [Range(6, 100)]
        public int Age { get; set; }

        [Display(Name = "Почта")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Логин")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтвердить пароль")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}