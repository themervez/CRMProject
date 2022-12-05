using CRM.DAL.Abstract;
using CRM.DAL.Concrete;
using CRM.DAL.Repository;
using CRM.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.EF
{
    public class EFEmployeeTaskDAL : GenericRepository<EmployeeTask>, IEmployeeTaskDAL
    {
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Include(x => x.AppUser).ToList();
                return values;
            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Where(x => x.AppUserId == id).ToList();
                return values;
            }
        }
    }
}
