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
        [DisplayName("Mã Sản Phẩm")]
        public int MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đơn Hàng")]
        public int MaDH { get; set; }
        [DisplayName("Số Lượng Mua")]
        public int? SoLuongMua { get; set; }

        [StringLength(100)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Sản Phẩm")]
        public string TenSP { get; set; }

        [StringLength(1)]
        [DisplayName("Giá")]
        public string Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
