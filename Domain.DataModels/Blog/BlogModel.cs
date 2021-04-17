using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataModels.Blog
{
    public class BlogModel
    {
        public int BlogId { get; set; }

        public string BTitle { get; set; }

        public string BCategory { get; set; }

        public string BDescription { get; set; }

        public DateTime BPostedDate { get; set; }
    }
}
