using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Contract
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Blog 
        {
            public const string GetAll = Base + "/GetAllBlogs";

            public const string Create = Base + "/CreateBlog";

            public const string Edit = Base + "/EditBlog";

            public const string Delete = Base + "/DeleteBlog/{blogId}";
        }

        public static class Token 
        {
            public const string GetToken = Base + "/GetToken";
        }
    }
}
