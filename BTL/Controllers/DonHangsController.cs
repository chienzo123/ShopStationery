using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL.Dao;
using BTL.Models;

namespace BTL.Controllers
{
    public class DonHangsController : Controller
    {
        private Model1 db = new Model1();
        private const string GioHangSession = "GioHangSession";
        // GET: DonHangs/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,TenNguoiNhan,SDTNguoiNhan,DiaChiNhan,Email,TinhTrang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                donHang.TinhTrang = "Đang xử lý";

                var id = new DonHangDao().DatHang(donHang);
                var ChiTietDao = new ChiTietDatHangDao();
                var GioHang = (List<ChiTietGioHang>)Session[GioHangSession];
                foreach (var item in GioHang)
                {
                    var ChiTiet = new ChiTietDonHang();
                    ChiTiet.MaSP = item.SP.MaSP;
                    ChiTiet.MaDH = donHang.MaDH;
                    ChiTiet.SoLuongMua = item.SoLuong;
                    ChiTiet.Anh = item.SP.Anh;
                    ChiTiet.TenSP = item.SP.TenSP;
                    ChiTiet.Gia = item.SP.Gia;
                    ChiTietDao.DatHang(ChiTiet);
                }
                db.SaveChanges();

                return Redirect("/DonHangs/HoanThanh");
            }

            return View(donHang);
        }

        public ActionResult HoanThanh()
        {
            var sessionGioHang = (List<ChiTietGioHang>)Session[GioHangSession];
            sessionGioHang.RemoveAll(x => x.SoLuong > 0);
            Session[GioHangSession] = sessionGioHang;
            return View();
        }
    }
}
