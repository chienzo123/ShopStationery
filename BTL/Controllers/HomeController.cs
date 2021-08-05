using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()//Trang chủ
        {
           
            return View();
        }

        public PartialViewResult _Nav()
        {
            var danhmucs = db.DanhMucs.Select(d => d);
            return PartialView(danhmucs);
        }
        public PartialViewResult _BestSeller()
        {
            var spbanchay = db.SanPhams.OrderByDescending(s => s.SoLuong).Take(8);
            return PartialView(spbanchay);
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


        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Acccount()//Tài Khoản
        {
            return View();
        }



    }
}