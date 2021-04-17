using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Blog
{
    public interface IBlogService
    {
        IEnumerable<Core.BusinessModels.Blog.Blog> GetAllBlogs();

        int CreateBlog(Core.BusinessModels.Blog.Blog blog);
        int EditBlog(BusinessModels.Blog.Blog blog);
        int DeleteBlog(int blogId);
    }
}
