﻿using BigSchool3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BigSchool3.ViewModels;

namespace BigSchool3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);
            var viewModel = new CourseViewModel
            {
                UpcomingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
            //return View(upcommingCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}