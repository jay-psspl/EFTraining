using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicMene.Controllers;
using DynamicMene.Models;
using System.Data.Entity;

namespace DynamicMene.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var db = new Model2())
            {
                var d = db.MainMenus.Include(c => c.SubMenus).ToList();
                return View(d);
            }
        }
    }
}