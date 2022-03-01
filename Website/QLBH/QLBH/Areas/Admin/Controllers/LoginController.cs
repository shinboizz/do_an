using QLBH.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using QLBH.Common;

namespace QLBH.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password),true);
                if (result==1)
                {
                    var user = dao.GetByUsername(model.Username);
                    var usersession = new UserLogin();
                    usersession.Username = user.TaiKhoan1;
                    usersession.UserID = user.ID;
                    //var listCredentials = dao.GetListCredential(model.Username);
                    //Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result==0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if(result==-1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if(result==-3)
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                }
                else
                {
                    ModelState.AddModelError("", "Sai mật khẩu.");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("Index");
        }
    }
}