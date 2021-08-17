using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RadioButtonForEx.Models;

namespace RadioButtonForEx.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ganesha2Entities db = new Models.ganesha2Entities();
            var data = db.Category5.ToList();
            RadioButtonListClass obj = new RadioButtonListClass();
            obj.selectedradio = "";
            obj.radiobuttionlist = data;
            
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(RadioButtonListClass obj)
        {
            if (obj.radiobuttionlist != null)
            {
                Session["item"] = obj.selectedradio;
            }
            return RedirectToAction("ShowData");
        }
        public ActionResult ShowData()
        {
            return View();
        }
    }
}