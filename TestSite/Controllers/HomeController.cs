﻿using System;
using System.Threading;
using System.Web.Mvc;
using TestSite.SimpleService;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Thread.Sleep(new Random().Next(2000));

            using (var client = new SimpleServiceClient())
            {
                ViewData["number"] = client.DoWork().ToString();
            }
            return View();
        }
    }
}
