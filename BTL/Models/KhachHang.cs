namespace BTL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenKH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Nhập đúng định dạng email")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        public int? DienThoai { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhau { get; set; }
    }
}
