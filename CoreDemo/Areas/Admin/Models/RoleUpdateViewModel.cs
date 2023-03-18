using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public int RoleId { get; set; }
        [Required(ErrorMessage="Lütfen bir rol adı giriniz.")]
        public string RoleName { get; set; }
    }
}
