namespace BTL.Areas.Admin.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }

        [Column("TaiKhoan")]
        [DisplayName("Tài kho?n")]
        [StringLength(100)]
        public string TaiKhoan1 { get; set; }

        [StringLength(100)]
        [DisplayName("M?t kh?u")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [DisplayName("Tên nhân viên")]
        public string TenNhanVien { get; set; }

        [StringLength(50)]
        [DisplayName("Quy?n")]
        public string Quyen { get; set; }
    }
}
