using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPVideo.Models;

namespace SPVideo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            var db = new angularEntities();
            var data = db.sp_getlogin();
            return View(data.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var db = new angularEntities();
            SqlParameter param1 = new SqlParameter("@id", id);
            var data = db.Database.SqlQuery<login>("exec sp_getloginbyid @id", param1).SingleOrDefault();
            return View(data);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(login collection)
        {
            try
            {
                // TODO: Add insert logic here

                SqlParameter param1 = new SqlParameter("@username", collection.username);
                SqlParameter param2 = new SqlParameter("@password", collection.password);
                var db = new angularEntities();
                var data = db.Database.ExecuteSqlCommand("sp_logininsert @username, @password", param1, param2);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new angularEntities();
            SqlParameter param1 = new SqlParameter("@id", id);
            var data = db.Database.SqlQuery<login>("exec sp_getloginbyid @id", param1).SingleOrDefault();
            return View(data);

        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, login obj)
        {
            try
            {
                // TODO: Add update logic here
                var db = new angularEntities();
                SqlParameter param1 = new SqlParameter("@username", obj.username);
                SqlParameter param2 = new SqlParameter("@password", obj.password);
                SqlParameter param3 = new SqlParameter("@id", id);
                var data = db.Database.ExecuteSqlCommand("sp_loginupdate @id, @username, @password", param3, param1, param2);
                // db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new angularEntities();
            SqlParameter param1 = new SqlParameter("@id", id);
            var data = db.Database.SqlQuery<login>("exec sp_getloginbyid @id", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var db = new angularEntities();
                SqlParameter param = new SqlParameter("@id", id);
                db.Database.ExecuteSqlCommand("sp_deletelogin @id", param);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
