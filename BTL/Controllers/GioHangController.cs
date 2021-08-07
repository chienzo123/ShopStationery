using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BTL.Dao;
using BTL.Models;
namespace BTL.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        private const string GioHangSession = "GioHangSession";
        Model1 db = new Model1();
        public ActionResult Index()
        {
            var GioHang = Session[GioHangSession];
            var list = new List<ChiTietGioHang>();
            if (GioHang != null)
            {
                list = (List<ChiTietGioHang>)GioHang;
            }
            return View(list);
        }
        public PartialViewResult _DatHang()
        {
            var GioHang = Session[GioHangSession];
            var list = new List<ChiTietGioHang>();
            if (GioHang != null)
            {
                list = (List<ChiTietGioHang>)GioHang;
            }
            return PartialView(list);
        }
        public ActionResult ThemSanPham(int MaSP, int SoLuong)
        {
            var sp = new SanPhamDao().ViewDetail(MaSP);
            var GioHang = Session[GioHangSession];
            if (GioHang != null)
            {
                var list = (List<ChiTietGioHang>)GioHang;
                if (list.Exists(x => x.SP.MaSP == MaSP))
                {
                    foreach (var item in list)
                    {
                        if (item.SP.MaSP == MaSP)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }
                }
                else
                {
                    var sanpham = new ChiTietGioHang();
                    sanpham.SP = sp;
                    sanpham.SoLuong = SoLuong;
                    list.Add(sanpham);
                    Session[GioHangSession] = list;
                }


            }
            else
            {
                var sanpham = new ChiTietGioHang();
                sanpham.SP = sp;
                sanpham.SoLuong = SoLuong;
                var list = new List<ChiTietGioHang>();
                list.Add(sanpham);
                Session[GioHangSession] = list;
            }
            return RedirectToAction("");
        }
        public JsonResult CapNhap(string GioHangdata)
        {
            var jsonGioHang = new JavaScriptSerializer().Deserialize<List<ChiTietGioHang>>(GioHangdata);
            var sessionGioHang = (List<ChiTietGioHang>)Session[GioHangSession];
            SanPhamDao check = new SanPhamDao();
            foreach (var item in jsonGioHang)
            {
                if (item.SoLuong == 0)
                    sessionGioHang.RemoveAll(x => x.SP.MaSP == item.SP.MaSP);
                Session[GioHangSession] = sessionGioHang;
            }
            foreach (var item in sessionGioHang)
            {
                foreach (var jitem in jsonGioHang)
                {
                    if (item.SP.MaSP == jitem.SP.MaSP)
                    {
                        SanPham spcheck = check.ViewDetail(item.SP.MaSP);
                        if (spcheck.SoLuong >= jitem.SoLuong)
                            item.SoLuong = jitem.SoLuong;
                    }
                }
            }
            Session[GioHangSession] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }



        [HttpPost]
        public JsonResult Xoa(int MaSP)
        {
            var sessionGioHang = (List<ChiTietGioHang>)Session[GioHangSession];
            sessionGioHang.RemoveAll(x => x.SP.MaSP == MaSP);
            Session[GioHangSession] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult XoaToanBo()
        {
            var sessionGioHang = (List<ChiTietGioHang>)Session[GioHangSession];
            sessionGioHang.RemoveAll(x => x.SoLuong > 0);
            Session[GioHangSession] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }

      
        
        public ActionResult Create()
        {
            return View();
        }
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,TenNguoiNhan,SDTNguoiNhan,DiaChiNhan,Email")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                donHang.TinhTrang = "Đang Xử Lý";
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
                db.DonHangs.Add(donHang);
                db.SaveChanges();
              
            }
            return Redirect("/GioHang/HoanThanh");
        }

    }
}