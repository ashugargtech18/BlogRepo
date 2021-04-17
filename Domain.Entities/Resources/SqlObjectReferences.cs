using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Resources
{
    public static class SqlObjectReferences
    {
        public const string GetAllBlogProc = "[dbo].[Usp_GetAllBlogs]";

        public const string CreateBlogProc = "[dbo].[Usp_CreateBlog]";

        public const string DeleteBlogQuery = "Delete from [dbo].[Blog] where BlogId = @blogId";
        
        public const string GetTokenProfile = "[dbo].[Usp_GetTokenProfile]";

        
    }
}
