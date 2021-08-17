using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestImage.Models;

namespace TestImage.Controllers
{
    public class TestImageController : Controller
    {
        // GET: TestImage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TBLimage tblimage)
        {

            string fileName = Path.GetFileNameWithoutExtension(tblimage.ImageFile.FileName);
            string extention = Path.GetExtension(tblimage.ImageFile.FileName);
            tblimage.Image = "../Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("../Image/"), fileName);
            tblimage.ImageFile.SaveAs(fileName);
            using (DBmodel dBmodel = new DBmodel())
            {
                dBmodel.TBLimages.Add(tblimage);
                dBmodel.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }
    }
}