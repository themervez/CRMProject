using CRM.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Abstract
{
    public interface IEmployeeService:IGenericService<Employee>
    {
        List<Employee> TGetEmployeesByCategory();//DAL kısmındaki metodla karışmaması için metod isminin başına T ekledik
        void TChangeEmployeeStatusToTrue(int id);
        void TChangeEmployeeStatusToFalse(int id);
    }
}
