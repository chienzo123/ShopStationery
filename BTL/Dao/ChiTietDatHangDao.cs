using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Dao
{
    public class ChiTietDatHangDao
    {
        Model1 db = new Model1();
        public bool DatHang(ChiTietDonHang chitiet)
        {
            db.ChiTietDonHangs.Add(chitiet);
            db.SaveChanges();
            return true;
        }
    }
}