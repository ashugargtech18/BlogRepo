using AutoMapper;
using Core.Interfaces.Blog;
using Domain.DataModels.Blog;
using Domain.Entities.Blog;
using Domain.Interfaces.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly IBlogDataService _blogService;

        private readonly IMapper _mapper;
        public BlogService(IBlogDataService blogService)
        {
            // create mapper 
            _mapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Core.BusinessModels.Blog.Blog, BlogModel>();
                cfg.CreateMap< BlogModel, Core.BusinessModels.Blog.Blog>();
                cfg.CreateMap<Core.BusinessModels.Blog.Blog, BlogDto>();
            }).CreateMapper(); ;


            _blogService = blogService;
        }

        /// <summary>
        /// Get All Blog
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessModels.Blog.Blog> GetAllBlogs()
        {
            var result = _blogService.GetAllBlogs();
            var model = _mapper.Map<List<Core.BusinessModels.Blog.Blog>>(result);
            return model;
        }

        /// <summary>
        /// Add new Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public int CreateBlog(BusinessModels.Blog.Blog blog)
        {
            var model = _mapper.Map<BlogDto>(blog);
            return _blogService.CreateBlog(model);
        }

        /// <summary>
        /// Edit blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public int EditBlog(BusinessModels.Blog.Blog blog)
        {
            var model = _mapper.Map<BlogDto>(blog);
            return _blogService.EditBlog(model);
        }
        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public int DeleteBlog(int blogId)
        {
            return _blogService.DeleteBlog(blogId);
        }
    }
}
