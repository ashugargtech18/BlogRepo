using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels.Blog
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string BTitle { get; set; }

        public string BCategory { get; set; }

        public string BDescription { get; set; }

        public DateTime BPostedDate { get; set; }
    }
}
