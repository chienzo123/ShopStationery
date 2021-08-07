using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL.Areas.Admin.Modal;
using PagedList;

namespace BTL.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/SanPhams
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;//Biến  lấy  yêu  cầu  sắp  xếp  hiện  tại
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";
            //Lấy  giá  trị  của  bô  lọc  dữ  liệu  hiện  tại
            if (searchString != null)
            {
                page = 1;  //Trang  đầu  tiên
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var sanPhams = db.SanPhams.Include(s => s.DanhMuc);
            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = sanPhams.Where(p => p.TenSP.Contains(searchString));
            }

            //Sắp  xếp
            switch (sortOrder)
            {
                case "name_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.TenSP); break;
                case "Gia":
                    sanPhams = sanPhams.OrderBy(s => s.Gia); break;
                case "gia_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.Gia); break;
                default:
                    sanPhams = sanPhams.OrderBy(s => s.TenSP); break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc");


            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaDanhMuc,TenSP,Gia,MoTa,Anh,Loai,SoLuong")] SanPham sanPham)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.Anh = FileName;
                    }
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = " Lỗi nhập dữ liệu" + ex.Message;
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaDanhMuc,TenSP,Gia,MoTa,Anh,Loai,SoLuong")] SanPham sanPham)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    sanPham.Anh = sanPham.Anh.Trim();
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.Anh = FileName;
                    }
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Error = " Lỗi nhập dữ liệu" + ex.Message;
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            try
            {
                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = " Không được xóa" + ex.Message;
                return View("Delete", sanPham);
            }
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
