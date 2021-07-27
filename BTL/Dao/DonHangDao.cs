using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Dao
{
    public class DonHangDao
    {
        Model1 db = new Model1();
        public long DatHang(DonHang dathang)
        {
            db.DonHangs.Add(dathang);
            db.SaveChanges();
            return dathang.MaDH;
        }
    }
}