using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BodyGenic.Models
{
    public class User
    {
        public string user_id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string dob { get; set; }
        public string fitness_level { get; set; }
        public string user_profile_type { get; set; } // client, trainer, nutritionist
        
        
    }
}