using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLBH.Common;

namespace QLBH.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page=1,int pageSize=5)
        {
            var dao = new ProductDao();
            var list = dao.GetList(page,pageSize);
            return View(list);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.MaLoaiSP = new SelectList(dao.GetList(), "MaLoaiSP", "TenLoaiSP", selectedId);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            //xử lý upload
            file.SaveAs(Server.MapPath("~/Content/CustomerContent/images/product/large-size/" + file.FileName));
            return "/Content/CustomerContent/images/product/large-size/" + file.FileName;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var dao = new ProductDao();
                model.NgayTao = DateTime.Now;
                model.NguoiTao = session.Username;
                string Result = dao.Insert(model);
                if (Result !="")
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        public ActionResult Edit(string id)
        {
            var dao = new ProductDao();
            var SP = dao.Find(id);
            SetViewBag();
            return View(SP);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var dao = new ProductDao();
                model.NguoiSua=session.Username;
                bool result = dao.Update(model);
                if (result == true)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        public ActionResult Delete(string id)
        {
            var dao = new ProductDao();
            bool result = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}