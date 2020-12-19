using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BodyGenic.Models
{
    public class Course
    {

        public String course_id { get; set; }
        public String CourseTitle { get; set; }
        public String CourseDescription { get; set; }

        public Boolean isPaid { get; set; }

        public DateTime CreatedOn { get; set; }

        public string owner { get; set; }

    }
}