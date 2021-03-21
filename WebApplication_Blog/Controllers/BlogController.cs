using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Blog.Models;

namespace WebApplication_Blog.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            BlogDb dbhandle = new BlogDb();
            ModelState.Clear();
            return View(dbhandle.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogModel bmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BlogDb sdb = new BlogDb();
                    if (sdb.Add(bmodel))
                    {
                        ViewBag.Message = "Blog Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            BlogDb db = new BlogDb();
            return View(db.GetBlog(Id));
        }

        [HttpPost]
        public ActionResult Edit(int id, BlogModel bmodel)
        {
            try
            {
                BlogDb sdb = new BlogDb();
                sdb.Update(bmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                BlogDb sdb = new BlogDb();
                if (sdb.Delete(id))
                {
                    ViewBag.AlertMsg = "Blog Deleted Successfully!!!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
