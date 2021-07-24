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
        [DisplayName("Mã Tài Khoản")]
        public int MaTK { get; set; }

        [Column("TaiKhoan")]
        [StringLength(100)]
        [DisplayName("Tài Khoản")]
        public string TaiKhoan1 { get; set; }

        [StringLength(100)]
        [DisplayName("Mật Khẩu")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Nhân Viên")]
        public string TenNhanVien { get; set; }

        [DisplayName("Quyền")]
        public bool? Quyen { get; set; }
    }
}
