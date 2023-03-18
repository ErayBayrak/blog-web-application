using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListCategoryWithWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();
            }
        }

        public List<Blog> GetListWithCategory()
        {
            using(var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }

        public Blog GetLastBlog()
        {
            using (var c = new Context())
            {
                return c.Blogs.OrderByDescending(x => x.BlogID).Take(1).FirstOrDefault(); 
            }
        }
    }
}
