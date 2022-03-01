using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace QLBH.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        // GET: Admin/News
        public ActionResult Index()
        {
            var dao = new NewsDao();
            var result = dao.GetList();
            return View(result);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            //xử lý upload
            file.SaveAs(Server.MapPath("~/Content/CustomerContent/images/blog-banner/" + file.FileName));
            return "/Content/CustomerContent/images/blog-banner/" + file.FileName;
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new NewsCategoryDao();
            ViewBag.MaLoaiTin = new SelectList(dao.GetList(), "MaLoaiTin", "TenLoaiTin", selectedId);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TinTuc model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                model.NgayTao = DateTime.Now;
                long result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "News");
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
            SetViewBag();
            var dao = new NewsDao();
            var result = dao.Find(id);
            return View(result);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                bool result = dao.Update(model);
                if (result == true)
                {
                    return RedirectToAction("Index", "News");
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
            var dao = new NewsDao();
            bool result = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}