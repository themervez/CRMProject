using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntityLayer.Concrete
{
   public class EmployeeTask
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<EmployeeTaskDetail> EmployeeTaskDetails { get; set; }
    }
}
