using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace QLBH.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            var dao = new AboutDao();
            var list = dao.GetList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            //xử lý upload
            file.SaveAs(Server.MapPath("~/Content/CustomerContent/images/product/large-size/" + file.FileName));
            return "/Content/CustomerContent/images/product/large-size/" + file.FileName;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(GioiThieu model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                long Result = dao.Insert(model);
                if (Result >0)
                {
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var dao = new AboutDao();
            var about = dao.Find(id);
            return View(about);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(GioiThieu model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                bool result = dao.Update(model);
                if (result == true)
                {
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            var dao = new AboutDao();
            bool result = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}