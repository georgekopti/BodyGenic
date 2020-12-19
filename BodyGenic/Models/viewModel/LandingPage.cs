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
        }

        public User User { get; set; }

    }
}