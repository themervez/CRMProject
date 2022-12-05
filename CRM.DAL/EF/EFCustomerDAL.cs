using CRM.DAL.Abstract;
using CRM.DAL.Repository;
using CRM.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.EF
{
    public class EFCustomerDAL : GenericRepository<Customer>, ICustomerDAL
    {
    }
}
