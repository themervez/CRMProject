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
    public class EmployeeTaskManager : IEmployeeTaskService
    {
        IEmployeeTaskDAL _employeeTaskDAL;

        public EmployeeTaskManager(IEmployeeTaskDAL employeeTaskDAL)
        {
            _employeeTaskDAL = employeeTaskDAL;
        }

        public void TDelete(EmployeeTask t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTask TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTask> TGetEmployeeTaskByEmployee()
        {
            return _employeeTaskDAL.GetEmployeeTaskByEmployee(); 
        }

        public List<EmployeeTask> TGetEmployeeTaskById(int id)
        {
            return _employeeTaskDAL.GetEmployeeTaskById(id);
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDAL.GetList();
        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDAL.Insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            throw new NotImplementedException();
        }
    }
}
