using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.UILayer.Areas.Employee.Models
{
    public class EmailRequest
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
        public string SenderEmail{ get; set; }

        [Required(ErrorMessage = "Lütfen Alıcı Mail Adresini Giriniz")]
        public string ReceiverEmail{ get; set; }
        public string Subject{ get; set; }
        public string Content{ get; set; }
    }
}
