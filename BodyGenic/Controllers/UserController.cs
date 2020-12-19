﻿using BodyGenic.Models;
using BodyGenic.Firebase_Queries;
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
    public class UserController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "FVQVcbV5gkErLtNwsDoJ8jqpfTeIEF2vMzQcV8rw",
            BasePath = "https://bodygenic-768eb-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Create(User user)
        {
            try {
                AddUserToFirebase(user);
                ModelState.AddModelError(string.Empty, "Added successfully");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            
            return View();
        }

        private void AddUserToFirebase(User user)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = user;
            PushResponse response = client.Push("Users/", data);
            data.user_id = response.Result.name;
            SetResponse setResponse = client.Set("Users/"+data.user_id, data);
        }

        public ActionResult UserLogin(LogInModel model)
        {

            //LandingPage landingPageItems = new LandingPage();
            //landingPageItems = (LandingPage)Session["landingPageItems"];
            //Session["landingPageItems"] = landingPageItems;

            //model.Email
            //model.password
            //User user = new User();

            User_Queries user_Queries = new User_Queries();

            List<User> users = user_Queries.RetrieveUsersFromFirebase();

            return View("Index");
        }
        

    }
}