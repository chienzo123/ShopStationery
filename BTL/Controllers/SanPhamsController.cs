using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BTL.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model1 db = new Model1();
        // GET: SanPhams
        public ActionResult Index(int id, string chuoitimkiem, string sortOrder,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";

            var sanphams = db.SanPhams.Select(s => s);
            if (!String.IsNullOrEmpty(chuoitimkiem))
            {
                page = 1;
                sanphams = db.SanPhams.Where(s => s.TenSP.Contains(chuoitimkiem));
            }
            else if (id != -1)
            {
                sanphams = db.SanPhams.Where(s => s.MaDanhMuc.Equals(id)).Select(s => s);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sanphams = sanphams.OrderByDescending(s => s.TenSP);
                    break;
                case "Gia":
                    sanphams = sanphams.OrderBy(s => s.Gia);
                    break;
                case "gia_desc":
                    sanphams = sanphams.OrderByDescending(s => s.Gia);
                    break;
                default:
                    sanphams = sanphams.OrderBy(s => s.TenSP);
                    break;
            }
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            return View(sanphams.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Detail(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //else
            //{
            var sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
            //}

        }
        public PartialViewResult _RelateProduct(int madanhmuc, int masanphamhientai)
        {
            var splienquan = db.SanPhams.Where(s => s.MaDanhMuc.Equals(madanhmuc) && !s.MaSP.Equals(masanphamhientai)).Take(4);
            return PartialView(splienquan);
        }
        public PartialViewResult _SideBar(int danhmuchientai)
        {
            var sidebar = db.SanPhams.Where(s => !s.MaDanhMuc.Equals(danhmuchientai)).Take(6).OrderBy(s=> s.MaSP);
            return PartialView(sidebar);
        }

    }
}