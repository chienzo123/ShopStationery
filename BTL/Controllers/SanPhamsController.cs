using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model1 db = new Model1();
        // GET: SanPhams
        public ActionResult Index(int danhmuc, string chuoitimkiem)
        {
            var sanphams = db.SanPhams.Select(s => s);
            if (!String.IsNullOrEmpty(chuoitimkiem) && danhmuc == -2)
            {
                sanphams = db.SanPhams.Where(s => s.TenSP.Contains(chuoitimkiem));
            }
            else if (danhmuc != -1)
            {
                sanphams = db.SanPhams.Where(s => s.MaDanhMuc.Equals(danhmuc)).Select(s => s);
            }
            return View(sanphams);
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
    }
}