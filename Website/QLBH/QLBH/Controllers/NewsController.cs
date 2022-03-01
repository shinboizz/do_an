using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace QLBH.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var dao = new NewsDao();
            var result = dao.GetList();
            return View(result);
        }
        public ActionResult Detail(long id)
        {
            var dao = new NewsDao();
            var result = dao.Find(id);
            return View(result);
        }
    }
}