using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using QLBH.Models;
using QLBH.Common;

namespace QLBH.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var dao = new SlideDao();
            var result = dao.GetList();
            return View(result);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            var dao = new AboutDao();
            var result = dao.GetList();
            return View(result);
        }
        
        public ActionResult NewsProduct(int status)
        {
            var dao = new ProductDao();
            var result = dao.GetByStatus(status);
            return View(result);
        }
        public ActionResult BestSeller(int status)
        {
            var dao = new ProductDao();
            var result = dao.GetByStatus(status);
            return View(result);
        }
        public ActionResult Featured(int status)
        {
            var dao = new ProductDao();
            var result = dao.GetByStatus(status);
            return View(result);
        }
        public ActionResult Menu()
        {
            var dao = new ProductCategoryDao();
            var result = dao.GetList();
            return View(result);
        }
      
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        public ActionResult TopMenu()
        {
            return View();
        }
    }
}