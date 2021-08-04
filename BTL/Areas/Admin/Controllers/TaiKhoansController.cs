﻿using System;
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
    public class TaiKhoansController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/TaiKhoans
        public ActionResult Index()
        {
            return View(db.TaiKhoans.ToList());
        }
        public ActionResult LoiDelete()
        {
            return View();
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTK,TaiKhoan1,MatKhau,TenNhanVien,Quyen,Khoa")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                if(taiKhoan.Quyen.ToString() == "Giám đốc")
                {
                    ViewBag.Error = "không thể thêm giám đốc mới";
                    
                }
                else
                {
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTK,TaiKhoan1,MatKhau,TenNhanVien,Quyen,Khoa")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            
            
            

                db.TaiKhoans.Remove(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public ActionResult Block(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            taiKhoan.Khoa = !taiKhoan.Khoa;
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
           
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Block([Bind(Include = "MaTK,TaiKhoan1,MatKhau,TenNhanVien,Quyen,Khoa")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Quyen = new SelectList( "Giám đốc", "Nhân Viên");
            return View(taiKhoan);
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
