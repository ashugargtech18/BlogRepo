using AppUtilities.Helpers;
using AutoMapper;
using BlogApi.Contract;
using BlogApi.Contract.Request;
using BlogApi.Contract.Response.Blog;
using Core.Interfaces.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers.V1
{
    [Authorize]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService)
        {
           _mapper = new MapperConfiguration(
           cfg =>
           {
               cfg.CreateMap<BlogResponse, Core.BusinessModels.Blog.Blog>();
               cfg.CreateMap<Core.BusinessModels.Blog.Blog, BlogRequest>();
               cfg.CreateMap<BlogRequest,Core.BusinessModels.Blog.Blog>();
               cfg.CreateMap< Core.BusinessModels.Blog.Blog, BlogResponse>();

           }).CreateMapper(); ;
            _blogService = blogService;
        }

        [HttpGet(template:ApiRoutes.Blog.GetAll)]
        public ActionResult Get()
        {
            var result = _blogService.GetAllBlogs();
            var data = _mapper.Map<List<BlogResponse>>(result);
            return Ok(new ResponseWrapper<List<BlogResponse>>
            { 
                Status = data.Count==0?Constants.MessageStatus.NotFound : Constants.MessageStatus.Success,
                Data  = data,
                Code = data.Count == 0? (int)Constants.StatusCode.BadRequest : (int)Constants.StatusCode.OK

            });
        }

        [HttpPost(template: ApiRoutes.Blog.Create)]
        public ActionResult Post([FromBody]BlogRequest blogRequest)
        {
            var model =_mapper.Map<Core.BusinessModels.Blog.Blog>(blogRequest);
            int check = _blogService.CreateBlog(model);
            return Ok(ResponseStatus.GetCreateStatus(check));
        }

        [HttpPut(template: ApiRoutes.Blog.Edit)]
        public ActionResult Put([FromBody] BlogRequest blogRequest)
        {
            var model = _mapper.Map<Core.BusinessModels.Blog.Blog>(blogRequest);
            int check = _blogService.EditBlog(model);
            return Ok(ResponseStatus.GetUpdateStatus(check));
        }

        [HttpDelete(template: ApiRoutes.Blog.Delete)]
        public ActionResult Delete([FromRoute] int blogId)
        {
            return Ok(ResponseStatus.GetDeleteStatus(_blogService.DeleteBlog(blogId)));
             
        }
    }
}
