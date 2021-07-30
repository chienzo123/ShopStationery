namespace BTL.Areas.Admin.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã sản phẩm")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã đơn hàng")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaDH { get; set; }
        [DisplayName("Số lượng mua")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int? SoLuongMua { get; set; }

        [StringLength(100)]
        [DisplayName("Ảnh")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string Anh { get; set; }

        [StringLength(50)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TenSP { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public decimal? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
