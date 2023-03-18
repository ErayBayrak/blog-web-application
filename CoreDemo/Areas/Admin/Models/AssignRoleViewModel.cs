using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class AssignRoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExists { get; set; }
    }
}
