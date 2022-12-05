using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntityLayer.Concrete
{
    public class EmployeeTaskDetail
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeTaskId { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
    }
}
