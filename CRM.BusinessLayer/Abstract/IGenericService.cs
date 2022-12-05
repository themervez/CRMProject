using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> TGetList();
        T TGetById(int id);
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        
    }
}
