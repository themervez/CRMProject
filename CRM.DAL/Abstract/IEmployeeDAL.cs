using CRM.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Abstract
{
    public interface IEmployeeDAL:IGenericDAL<Employee>
    {
        List<Employee>GetEmployeesByCategory();
        void ChangeEmployeeStatusToTrue(int id);
        void ChangeEmployeeStatusToFalse(int id);
    }
}
