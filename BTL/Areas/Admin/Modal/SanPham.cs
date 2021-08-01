namespace BTL.Areas.Admin.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [DisplayName("Mã sản phẩm")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaSP { get; set; }
        [DisplayName("Mã danh mục")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaDanhMuc { get; set; }

        [StringLength(50)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TenSP { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        [DisplayName("Giá")]

        public decimal? Gia { get; set; }

        [StringLength(200)]
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string MoTa { get; set; }

        [StringLength(200)]
        [DisplayName("Ảnh")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        [Column(TypeName ="text")]
        public string Anh { get; set; }

        [StringLength(100)]
        [DisplayName("Loại")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string Loai { get; set; }
        [DisplayName("Số Lượng")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
