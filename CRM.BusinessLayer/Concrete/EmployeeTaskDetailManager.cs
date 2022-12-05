using CRM.BusinessLayer.Abstract;
using CRM.DAL.Abstract;
using CRM.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Concrete
{
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        private readonly IEmployeeTaskDetailDAL _employeeTaskDetailDAL;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDAL employeeTaskDetailDAL)
        {
            _employeeTaskDetailDAL = employeeTaskDetailDAL;
        }

        public void TDelete(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTaskDetail TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTaskDetail> TGetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDAL.GetEmployeeTaskDetailById(id);
        }

        public List<EmployeeTaskDetail> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }
    }
}
