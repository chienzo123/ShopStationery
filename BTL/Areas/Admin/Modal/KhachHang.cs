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
        [DisplayName("Mã khách hàng")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaKH { get; set; }

        [StringLength(100)]
        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TenKH { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string Email { get; set; }
        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int? DienThoai { get; set; }

        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string MatKhau { get; set; }
    }
}
