using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QLBH.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int page=1,int pageSize=5)
        {
            var dao = new ProductDao();
            var result = dao.GetList(page,pageSize);
            return View(result);
        }
        public ActionResult ProductByCat(long idCat)
        {
            var dao = new ProductDao();
            var result = dao.GetByIDCat(idCat);
            return View(result);
        }
        public ActionResult Detail(string id)
        {
            var dao = new ProductDao();
            var result = dao.Find(id);
            return View(result);
        }
        public ActionResult SameProduct(long idCat)
        {
            var dao = new ProductDao();
            var result = dao.GetByIDCat(idCat);
            return View(result);
        }
        public JsonResult ListName(string q)
        {
            var dao = new ProductDao();
            var result = dao.ListName(q);
            return Json(new
            {
                data = result,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword,int page=1,int pageSize=2)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totaPage = 0;

            totaPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totaPage;
            ViewBag.Maxpage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totaPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}