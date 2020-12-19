using BodyGenic.Models;
using BodyGenic.Models.viewModel;
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
    public class ProfileController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "FVQVcbV5gkErLtNwsDoJ8jqpfTeIEF2vMzQcV8rw",
            BasePath = "https://bodygenic-768eb-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        // GET: Profile
        public ActionResult Index()
        {

            LandingPage landingPageItems = new LandingPage();
            landingPageItems = (LandingPage)Session["landingPageItems"];
            return View(landingPageItems);
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        private void AddPostToFirebase2(Post post)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = post;
            PushResponse response = client.Push("Posts/", data);
            data.post_id = response.Result.name;
            SetResponse setResponse = client.Set("Posts/" + data.post_id, data);
        }

        public ActionResult AddPostToFirebase(Post post)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = post;
            PushResponse response = client.Push("Posts/", data);
            data.post_id = response.Result.name;
            SetResponse setResponse = client.Set("Posts/" + data.post_id, data);

            LandingPage landingPageItems = new LandingPage();
            landingPageItems = (LandingPage)Session["landingPageItems"];

            Firebase_Queries.User_Queries firebase = new Firebase_Queries.User_Queries();
            landingPageItems.Posts = firebase.RetrievePostsFromFirebase();

            return RedirectToAction("Index", "Home");
        }

        public List<Post> RetrievePostsFromFirebase()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Posts");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list2 = new List<Post>();
            foreach (var post in data)
            {
                list2.Add(JsonConvert.DeserializeObject<Post>(((JProperty)post).Value.ToString()));
            }
            return list2;
        }

        

    }
}