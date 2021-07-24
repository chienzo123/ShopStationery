﻿namespace BTL.Areas.Admin.Modal
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
        [DisplayName("Mã Sản Phẩm")]
        public int MaSP { get; set; }

        [DisplayName("Mã Danh Mục")]
        public int MaDanhMuc { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Sản Phẩm")]
        public string TenSP { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá Sản Phẩm")]
        public decimal? Gia { get; set; }

        [StringLength(200)]
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }

        [StringLength(200)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [StringLength(100)]
        [DisplayName("Loại")]
        public string Loai { get; set; }

        [DisplayName("Số Lượng")]
        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
