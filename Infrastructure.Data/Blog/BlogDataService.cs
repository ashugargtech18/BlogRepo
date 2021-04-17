using Dapper;
using Domain.DataModels.Blog;
using Domain.Entities.Blog;
using Domain.Entities.Resources;
using Domain.Interfaces;
using Domain.Interfaces.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Blog
{
    public class BlogDataService : IBlogDataService
    {
        private readonly IConnectionDataService _connection;
        public BlogDataService(IConnectionDataService connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Get All Blogs 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogModel> GetAllBlogs()
        {
           return _connection.GetConnection.Query<BlogModel>(SqlObjectReferences.GetAllBlogProc, null, commandType: System.Data.CommandType.StoredProcedure).AsList();
        }

        /// <summary>
        /// Create Blog
        /// </summary>
        /// <param name="blogDto"></param>
        /// <returns></returns>
        public int CreateBlog(BlogDto blogDto) 
        { 
            var param = new DynamicParameters();
            blogDto.BlogId = 0;
            param.Add("@BlogId",blogDto.BlogId);
            param.Add("@BTitle", blogDto.BTitle);
            param.Add("@BCategory", blogDto.BCategory);
            param.Add("@BDescription", blogDto.BDescription);
            param.Add("@BPostedDate", blogDto.BPostedDate);
            param.Add("@SaveStatus",dbType: System.Data.DbType.Int32,direction:System.Data.ParameterDirection.Output);

            _connection.GetConnection.Execute(SqlObjectReferences.CreateBlogProc,param,commandType :  System.Data.CommandType.StoredProcedure);

            return param.Get<int>("SaveStatus");

        }
        /// <summary>
        /// Edit Blog
        /// </summary>
        /// <param name="blogDto"></param>
        /// <returns></returns>
        public int EditBlog(BlogDto blogDto)
        {
            var param = new DynamicParameters();
            
            param.Add("@BlogId", blogDto.BlogId);
            param.Add("@BTitle", blogDto.BTitle);
            param.Add("@BCategory", blogDto.BCategory);
            param.Add("@BDescription", blogDto.BDescription);
            param.Add("@BPostedDate", blogDto.BPostedDate);
            param.Add("@SaveStatus", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            _connection.GetConnection.Execute(SqlObjectReferences.CreateBlogProc, param, commandType: System.Data.CommandType.StoredProcedure);

            return param.Get<int>("SaveStatus");

        }
        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public int DeleteBlog(int blogId)
        {
            return _connection.GetConnection.Execute(SqlObjectReferences.DeleteBlogQuery, new { blogId }, commandType: System.Data.CommandType.Text);
        }
    }
}
