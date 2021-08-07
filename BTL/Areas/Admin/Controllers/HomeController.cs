using BTL.Areas.Admin.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
  

        public ActionResult Block()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string TaiKhoan1, string MatKhau)
        {

            if (ModelState.IsValid)
            {

                Session.Clear();
                
                var user = db.TaiKhoans.Where(u => u.TaiKhoan1.Equals(TaiKhoan1) && u.MatKhau.Equals(MatKhau)).ToList();

               
                if (user.Count() > 0  )
                    {
                    if (user.FirstOrDefault().Khoa.ToString() == "True")
                    {
                        return RedirectToAction("Block");
                    }
                    else
                    {
                        Session["HoTen"] = user.FirstOrDefault().TenNhanVien;
                        Session["ChucVu"] = user.FirstOrDefault().Quyen;
                        Session["idUser"] = user.FirstOrDefault().MaTK;
                        return RedirectToAction("Index");
                    }
                    }
                    
                    else
                        {
                            ViewBag.Error = "Đăng nhập không thành công !";
                        }
                
            }

            return View();
        }
       

    }
}