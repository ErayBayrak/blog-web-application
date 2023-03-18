using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class AdminSignUpViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Kullanıcı adınız 3 karakterden az olamaz")]
        [MaxLength(20, ErrorMessage = "Kullanıcı adınız 20 karakterden fazla olamaz")]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Compare("password",ErrorMessage ="Girdiğiniz şifreler uyuşmuyor")]
        public string confirmPassword { get; set; }
        [Required]
        public string role { get; set; }
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string nameSurname { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string mail { get; set; }
    }
}
