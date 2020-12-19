using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BodyGenic.Models
{
    public class Post
    {
        public String post_id { get; set; }
        public String PostTitle { get; set; }
        public String PostBody { get; set; }
        public DateTime CreatedOn { get; set; }
        public string owner { get; set; }

    }
}