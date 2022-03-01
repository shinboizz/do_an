using Model.Dao;
using Model.EF;
using QLBH.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        //[HasCredential(RoleID ="VIEW_USER")]
        public ActionResult Index()
        {
            var dao = new UserDao();
            var result = dao.GetList();
            return View(result);
        }
        //[HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(string selectedId = null)
        {
            var dao = new UserGroupDao();
            ViewBag.IDQuyen = new SelectList(dao.GetList(), "ID", "Name", selectedId);
        }
        [HttpPost]
        public ActionResult Create(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(model.MatKhau);
                model.MatKhau = encryptedMd5Pas;
                model.NgayTao = DateTime.Now;
                long result = dao.Insert(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(long id)
        {
            SetViewBag();
            var dao = new UserDao();
            var result = dao.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(!string.IsNullOrEmpty(model.MatKhau))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(model.MatKhau);
                    model.MatKhau = encryptedMd5Pas;
                }
                bool result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }

            }
            return View("Index");
        }
        //[HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(long id)
        {
            var dao = new UserDao();
            bool result = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}