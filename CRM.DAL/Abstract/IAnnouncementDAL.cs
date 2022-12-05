using CRM.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Abstract
{
   public interface IAnnouncementDAL:IGenericDAL<Announcement>
    {
        public List<Announcement> ContainA();
    }
}
