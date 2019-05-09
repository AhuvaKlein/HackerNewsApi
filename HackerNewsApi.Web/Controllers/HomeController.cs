using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackerNewsApi.Web.Models;
using HackerNewsApi.Api;

namespace HackerNewsApi.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TopNewRepository repo = new TopNewRepository();
            return View(repo.GetTopNews());
        }

    }
}
