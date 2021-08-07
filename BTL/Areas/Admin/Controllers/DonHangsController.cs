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
    public class DonHangsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/DonHangs
        public ActionResult Index()
        {
            return View(db.DonHangs.ToList());
        }
       
        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,TenNguoiNhan,SDTNguoiNhan,DiaChiNhan,Email,TinhTrang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,TenNguoiNhan,SDTNguoiNhan,DiaChiNhan,Email,TinhTrang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
            List<ChiTietDonHang> ctdh = new List<ChiTietDonHang>();
            foreach(var item in db.ChiTietDonHangs)
            {
                if(item.MaDH == id)
                {
                    ctdh.Add(item);
                }
            }
            foreach(var item in ctdh)
            {
                db.ChiTietDonHangs.Remove(item);
            }

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
