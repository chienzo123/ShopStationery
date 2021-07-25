using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL.Areas.Admin.Modal;

namespace BTL.Areas.Admin.Controllers
{
    public class ChiTietDonHangsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/ChiTietDonHangs
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var donHang = db.ChiTietDonHangs.Select(p => p);

            if (donHang == null)
            {
                return HttpNotFound();
            }
            donHang = donHang.Where(p => p.MaDH.ToString().Contains(id.ToString()));
            return View(donHang.ToList());
        }

        // GET: Admin/ChiTietDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        // POST: Admin/ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaDH,SoLuongMua,Anh,TenSP,Gia")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonHangs.Add(chiTietDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan", chiTietDonHang.MaDH);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietDonHang.MaSP);
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan", chiTietDonHang.MaDH);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietDonHang.MaSP);
            return View(chiTietDonHang);
        }

        // POST: Admin/ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaDH,SoLuongMua,Anh,TenSP,Gia")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "TenNguoiNhan", chiTietDonHang.MaDH);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietDonHang.MaSP);
            return View(chiTietDonHang);
        }

        // GET: Admin/ChiTietDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonHang);
        }

        // POST: Admin/ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            db.ChiTietDonHangs.Remove(chiTietDonHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
