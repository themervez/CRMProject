using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntityLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int ID{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public string ImageUrl{ get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool Status { get; set; }
    }
}
