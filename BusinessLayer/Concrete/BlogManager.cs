using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
       
        //Constructor yapısı sayesinde EfBlogRepository'e erişerek fonksiyonları kullanabiliyoruz.
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetListWithCategoryByWriterBM(int id)
        {
            return _blogDal.GetListCategoryWithWriter(id);
        }
        public List<Blog> GetLas3Blog()
        {
            return _blogDal.GetList().TakeLast(3).ToList();
        }
      
        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetList(x => x.BlogID == id);
        }
        
        public List<Blog> GetList()
        {
           return _blogDal.GetList();
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.GetList(x => x.WriterID == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public Blog GetLastBlog()
        {
           return _blogDal.GetLastBlog();
        }
    }
}
