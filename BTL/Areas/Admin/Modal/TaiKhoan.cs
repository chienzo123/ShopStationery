namespace BTL.Areas.Admin.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }

        [Column("TaiKhoan")]
        [StringLength(100)]
        public string TaiKhoan1 { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        public bool? Quyen { get; set; }
    }
}
