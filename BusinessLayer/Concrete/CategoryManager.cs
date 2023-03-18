using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryService 
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
           return _categoryDal.GetList();
        }

        public void TAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void TDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void TUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
