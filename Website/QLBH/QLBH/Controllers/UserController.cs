using BotDetect.Web.UI.Mvc;
using Model.Dao;
using Model.EF;
using QLBH.Common;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUsername(model.Username);
                    var usersession = new UserLogin();
                    usersession.Username = user.TaiKhoan1;
                    usersession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else
                {
                    ModelState.AddModelError("", "Sai mật khẩu.");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCaptcha","Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new TaiKhoan();
                    user.TaiKhoan1 = model.UserName;
                    user.Ten = model.Name;
                    user.MatKhau = Encryptor.MD5Hash(model.Password);
                    user.SDT = model.Phone;
                    user.Email = model.Email;
                    user.DiaChi = model.Address;
                    user.NgayTao = DateTime.Now;
                    user.TrangThai = true;
                    var result= dao.Insert(user);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }
       
    }
}