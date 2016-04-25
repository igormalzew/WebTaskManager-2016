﻿using System;
using System.Web.Mvc;
using WebTaskManager.Filters;
using WebTaskManager.Manager;
using WebTaskManager.Models.repository;

namespace WebTaskManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
       
       private readonly UserManager _userManager = new UserManager();

        public ActionResult Index()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo == null)
            {
                ViewBag.IsAuthorized = false;
                ViewBag.UserName = String.Empty;
                return View();
            }

            ViewBag.IsAuthorized = true;
            ViewBag.UserName = userInfo[0];
            return RedirectToAction("MainPage", "home");
        }


        public ActionResult MainPage()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo == null)
            {
                ViewBag.IsAuthorized = false;
                ViewBag.UserName = String.Empty;
                return RedirectToAction("index", "home");
            }

            ViewBag.IsAuthorized = true;
            ViewBag.UserName = userInfo[0];
            return View();
        }

        public ActionResult Registration()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo == null)
            {
                ViewBag.IsAuthorized = false;
                ViewBag.UserName = String.Empty;
                return View();
            }

            ViewBag.IsAuthorized = true;
            ViewBag.UserName = userInfo[0];
            return View();
        }

        public ActionResult LogOut()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo == null)
            {
                ViewBag.IsAuthorized = false;
                ViewBag.UserName = String.Empty;
                return RedirectToAction("index", "home");
            }

            _userManager.UserLogOut(System.Web.HttpContext.Current.Request.Cookies["id"].Value);

            ViewBag.IsAuthorized = false;
            ViewBag.UserName = String.Empty;
            return RedirectToAction("index", "home");
        }

        public ActionResult About()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo == null)
            {
                ViewBag.IsAuthorized = false;
                ViewBag.UserName = String.Empty;
                return View();
            }

            ViewBag.IsAuthorized = true;
            ViewBag.UserName = userInfo[0];
            return View();
        }

        public ActionResult Contact()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo == null)
            {
                ViewBag.IsAuthorized = false;
                ViewBag.UserName = String.Empty;
                return View();
            }

            ViewBag.IsAuthorized = true;
            ViewBag.UserName = userInfo[0];
            return View();
        }

        public JsonResult AddNewUser(string birthDay, string email, string login, string name, string password)
        {
            return _userManager.AddNewUser(birthDay, email, login, name, password);
        }

        public JsonResult GetTasks(string filter)
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo != null)
            {
                return _userManager.GetTasks(Convert.ToInt32(userInfo[1]), filter);
            }
            return null;
        }

        public JsonResult GetCategory()
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo != null)
            {
                return _userManager.GetCategory(Convert.ToInt32(userInfo[1]));
            }
            return null;
        }

        public JsonResult AddCategory(string category)
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo != null)
            {
                return _userManager.AddCategory(Convert.ToInt32(userInfo[1]), category);
            }
            return null;
        }

        public JsonResult RemoveCategory(string category)
        {
            var userInfo = AccessVerify.GetInfoAuthorizedUser(System.Web.HttpContext.Current);
            if (userInfo != null)
            {
                return _userManager.RemoveCategory(Convert.ToInt32(userInfo[1]), category);
            }
            return null;
        }
    }
}