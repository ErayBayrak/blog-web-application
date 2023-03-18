using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        public List<Blog> GetBlogById(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListWithWriter(int id);
        Blog GetLastBlog();
    }
}
