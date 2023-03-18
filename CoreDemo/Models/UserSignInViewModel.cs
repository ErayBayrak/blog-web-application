using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adı Girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Girin")]
        public string password { get; set; }
    }
}
