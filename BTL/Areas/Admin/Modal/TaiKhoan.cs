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
        [DisplayName("Mã tài khoản")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaTK { get; set; }

        [Column("TaiKhoan")]
        [StringLength(100)]
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TaiKhoan1 { get; set; }

        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Không đươc để trống!")]

        public string MatKhau { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Nhân viên")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TenNhanVien { get; set; }

        [StringLength(20)]
        [DisplayName("Chức vụ")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string Quyen { get; set; }
        [DisplayName("Khóa")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public bool? Khoa { get; set; }

        
        
    }
}
