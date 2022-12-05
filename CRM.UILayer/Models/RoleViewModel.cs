using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Rol Adını Boş Geçmeyiniz.")]
        public string RoleName { get; set; }
    }
}
