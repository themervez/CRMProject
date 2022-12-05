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
    public class EFAnnouncementDAL : GenericRepository<Announcement>, IAnnouncementDAL
    {
        public List<Announcement> ContainA()
        {
            using (var context = new Context())
            {
                var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
                return values;//Title içinde 'a' harfi geçenleri getirmek için metodun içeriğini oluşturduk
            }
        }
    }
}
