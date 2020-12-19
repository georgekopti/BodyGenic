using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BodyGenic.Models;

namespace BodyGenic.Models.viewModel
{
    public class LandingPage
    {

        public LandingPage()
        {
            User = new User();
            Courses = new List<Course>();
        }

        public User User { get; set; }
        public List<Course> Courses { get; set; }

    }
}