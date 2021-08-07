using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL.Models;

namespace BTL.Controllers
{
    public class KhachHangsController : Controller
    {
        private Model1 db = new Model1();
      

        // GET: KhachHangs
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        // GET: KhachHangs/Details/5
        //[HttpGet]
        public ActionResult Detail()
        {

            return View();
        }

        // GET: KhachHangs/Create
        public ActionResult Registers()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registers([Bind(Include = "MaKH,TenKH,DiaChi,Email,DienThoai,TaiKhoan,MatKhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(khachHang);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var user = db.KhachHangs.Where(u => u.Email.Equals(email) && u.MatKhau.Equals(matkhau)).ToList();
                if (user.Count() > 0)
                {
                    
                    Session["TenKH"] = user.FirstOrDefault().TenKH;
                    Session["MaKH"] = user.FirstOrDefault().MaKH;
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["DienThoai"] = user.FirstOrDefault().DienThoai;
                    Session["Diachi"] = user.FirstOrDefault().DiaChi;
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    
                    ViewBag.Error = "Tài khoản hoặc mặt khẩu không chính xác";
                }
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,DiaChi,Email,DienThoai,MatKhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                Session["TenKH"] = khachHang.TenKH;
                Session["MaKH"] = khachHang.MaKH;
                Session["Email"] = khachHang.Email;
                Session["DienThoai"] = khachHang.DienThoai;
                Session["Diachi"] = khachHang.DiaChi;
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Detail");
            }
            return View(khachHang);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //public ActionResult DangKy()
        //{
        //    return View();
        //}
        public PartialViewResult _ChiTietDonHang()
        {
            string check = (string)Session["Email"];
            var query = db.DonHangs.Where(x => x.Email.ToString() == check);
            var list = new List<DonHang>();
            list = query.ToList();
            return PartialView(list);
        }

    }
}
