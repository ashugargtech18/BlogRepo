using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Contract.Request
{
    public class BlogRequest
    {
        public int BlogId { get; set; }

        public string BTitle { get; set; }

        public string BCategory { get; set; }

        public string BDescription { get; set; }

        public DateTime BPostedDate { get; set; }
    }
}
