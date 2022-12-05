using CRM.DAL.Abstract;
using CRM.DAL.Concrete;
using CRM.DAL.Repository;
using CRM.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.EF
{
    public class EFEmployeeTaskDetailDAL : GenericRepository<EmployeeTaskDetail>, IEmployeeTaskDetailDAL
    {
        public List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id)
        {
            using(var context= new Context())
            {
                return context.EmployeeTaskDetails.Where(x => x.EmployeeTaskId == id).ToList();
            }
        }
    }
}
