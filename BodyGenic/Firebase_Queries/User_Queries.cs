using BodyGenic.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BodyGenic.Firebase_Queries
{
    public class User_Queries
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "FVQVcbV5gkErLtNwsDoJ8jqpfTeIEF2vMzQcV8rw",
            BasePath = "https://bodygenic-768eb-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;


        public List<User> RetrieveUsersFromFirebase()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Users");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<User>();
            foreach (var user in data)
            {
                list.Add(JsonConvert.DeserializeObject<User>(((JProperty)user).Value.ToString()));
            }
            return list;
        }

        public List<Course> RetrieveCoursesFromFirebase()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Courses");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Course>();
            if (data != null)
            {
                foreach (var course in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Course>(((JProperty)course).Value.ToString()));
                }
            }
            
            return list;
        }



    }
}