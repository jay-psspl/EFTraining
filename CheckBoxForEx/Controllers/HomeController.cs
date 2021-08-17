using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckBoxForEx.Models;
using System.Web.Mvc;
using System.Text;

namespace CheckBoxForEx.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ganesha2Entities db = new ganesha2Entities();
            var data = db.Category5.ToList();
            CategoryList forchecklist = new Models.CategoryList();
            forchecklist.categorylist = data;
            return View(forchecklist);
        }
        [HttpPost]
        public ActionResult Index(CategoryList cat)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in cat.categorylist)
            {
                if (item.isselected)
                {
                    sb.Append(item.CategoryName + ",");
                }
            }

            int lastindex = sb.ToString().LastIndexOf(",");
            sb.Remove(lastindex, 1);
            Session["mydata"] = sb;
            return RedirectToAction("ShowData");
        }
        public ActionResult ShowData()
        {
            return View();
        }
    }
}