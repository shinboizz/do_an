using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace QLBH.Areas.Admin.Controllers
{
    public class NewsCategoryController : BaseController
    {
        // GET: Admin/NewsCategory
        public ActionResult Index()
        {
            var dao = new NewsCategoryDao();
            var result = dao.GetList();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiTin model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsCategoryDao();
                model.NgayTao = DateTime.Now;
                long result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "NewsCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        public ActionResult Edit(long id)
        {
            var dao = new NewsCategoryDao();
            var result = dao.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(LoaiTin model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsCategoryDao();
                bool result = dao.Update(model);
                if (result == true)
                {
                    return RedirectToAction("Index", "NewsCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        public ActionResult Delete(long id)
        {
            var dao = new NewsCategoryDao();
            bool result = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}