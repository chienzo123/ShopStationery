using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//Trang chủ
        {
            return View();
        }

        public ActionResult Details()//Chi tiết
        {
          

            return View();
        }

        public ActionResult Contact()//Liên hệ
        {
           

            return View();
        }
        public ActionResult Caterogy()//Danh Mục
        {
            return View();
        }
        public ActionResult Oder()//Đặt Hàng
        {
            return View();
        }
        public ActionResult Card()//Giỏ Hàng
        {
            return View();
        }
        public ActionResult Register()//Đăng Ký
        {
            return View();
        }
        public ActionResult Login()//Đăng nhập
        {
            return View();
        }
        public ActionResult Acccount()//Tài Khoản
        {
            return View();
        }



    }
}