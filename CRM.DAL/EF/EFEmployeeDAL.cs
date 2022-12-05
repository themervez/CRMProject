using CRM.DAL.Abstract;
using CRM.DAL.Concrete;
using CRM.DAL.Repository;
using CRM.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRM.DAL.EF
{
    public class EFEmployeeDAL : GenericRepository<Employee>, IEmployeeDAL
    {
        public void ChangeEmployeeStatusToFalse(int id)
        {
            using (var context = new Context())
            {
                var values = context.Employees.Find(id);
                values.Status = false;
                context.SaveChanges();
            }
        }

        public void ChangeEmployeeStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var values = context.Employees.Find(id);
                values.Status = true;
                context.SaveChanges();
            }
        }

        public List<Employee> GetEmployeesByCategory()//IEmployeeDAL içerisine harici tanımladığımız GetEmployeesByCategory metodunu burada implemente ettik
        {
            using (var context = new Context())
            {
                return context.Employees.Include(x => x.Category).ToList();//Employee tablosunun Categori tablosunu da içermesini sağladıl Include ile çağırmak istediğim entity'i kullanarak
            }
        }
    }
}
