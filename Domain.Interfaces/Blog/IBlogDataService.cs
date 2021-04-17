using Domain.DataModels.Blog;
using Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Blog
{
    public interface IBlogDataService
    {
        IEnumerable<BlogModel> GetAllBlogs();

        int CreateBlog(BlogDto blogDto);
        int EditBlog(BlogDto blogDto);

        int DeleteBlog(int blogId);
    }
}
