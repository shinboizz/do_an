using Model.Dao;
using Model.EF;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QLBH.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [ValidateInput(false)]
        public ActionResult AddItem(string productID,int quantity)
        {
            var product = new ProductDao().Find(productID);
            var cart = Session[CartSession];
            if(cart!=null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.Product.MaSP==productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.MaSP == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //Tạo mới đối tượng
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.MaSP == item.Product.MaSP);
                if(jsonItem!=null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(string id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.MaSP == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName,string mobile,string address,string email)
        {
            var order = new GioHang();
            order.NgayTao = DateTime.Now;
            order.ShipAddress = address;
            order.ShipEmail = email;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new ChiTietGioHang();
                    orderDetail.MaSP = item.Product.MaSP;
                    orderDetail.IDGioHang = id;
                    orderDetail.DonGia = item.Product.DonGia;
                    orderDetail.SoLuong = item.Quantity;
                    detailDao.Insert(orderDetail);
                }
            }
          catch
            {
                return Redirect("Error");
            }
           
            return Redirect("Success");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}