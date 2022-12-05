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
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void TDelete(Category t)
        {
            _categoryDAL.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categoryDAL.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDAL.GetList();
        }

        public void TInsert(Category t)
        {
            //if (t.Name!=null && t.Name.Length>=2 && t.Description.StartsWith("A"))//RuleFors,exmp. Fluent Validation kullanılacak
            //{
            //    _categoryDAL.Insert(t);
            //}
            //else
            //{
            //    //Hata Mesajı
            //}
            _categoryDAL.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDAL.Update(t);
        }
    }
}
