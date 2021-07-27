using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Dao
{
    public class SanPhamDao
    {
        Model1 db = new Model1();
        public SanPham ViewDetail(int id)
        {
            return db.SanPhams.Find(id);
        }
    }
}