namespace BTL.Areas.Admin.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [DisplayName("Mã Khách Hàng")]
        public int MaKH { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Khác Hàng")]
        public string TenKH { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Điện Thoại")]
        public int? DienThoai { get; set; }

        [StringLength(100)]
        [DisplayName("Tài Khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(100)]
        [DisplayName("Mật Khẩu")]
        public string MatKhau { get; set; }
    }
}
