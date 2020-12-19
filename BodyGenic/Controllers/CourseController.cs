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
using System.Web.Mvc;

namespace BodyGenic.Controllers
{
    public class CourseController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "FVQVcbV5gkErLtNwsDoJ8jqpfTeIEF2vMzQcV8rw",
            BasePath = "https://bodygenic-768eb-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCourse(Course course)
        {
            try
            {
                AddCourseToFirebase(course);
                ModelState.AddModelError(string.Empty, "Added successfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        private void AddCourseToFirebase(Course course)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = course;
            PushResponse response = client.Push("Courses/", data);
            data.course_id = response.Result.name;
            SetResponse setResponse = client.Set("Courses/" + data.course_id, data);
        }



        private ViewResult RetrieveCoursesFromFirebase()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Courses");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Course>();
            foreach (var course in data)
            {
                list.Add(JsonConvert.DeserializeObject<Course>(((JProperty)course).Value.ToString()));
            }
            return View(list);
        }

    }
}