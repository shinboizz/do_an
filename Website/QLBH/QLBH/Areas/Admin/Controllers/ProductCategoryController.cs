using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using QLBH.Common;

namespace QLBH.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var dao = new ProductCategoryDao();
            var list = dao.GetList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiSanPham model)
        {
           if(ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var dao = new ProductCategoryDao();
                model.NgayTao = DateTime.Now;
                model.NguoiTao = session.Username;
                long Ma = dao.Insert(model);
                if(Ma>0)
                {
                    return RedirectToAction("Index", "ProductCategory");
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
            var dao = new ProductCategoryDao();
            var LoaiSP = dao.Find(id);
            return View(LoaiSP);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSanPham model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var dao = new ProductCategoryDao();
                model.NguoiSua = session.Username;
                bool result = dao.Update(model);
                if (result == true)
                {
                    return RedirectToAction("Index", "ProductCategory");
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
            var dao = new ProductCategoryDao();
            bool result = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}