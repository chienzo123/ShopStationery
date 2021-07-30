namespace BTL.Areas.Admin.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [DisplayName("Mã đơn hàng")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int MaDH { get; set; }

        [StringLength(100)]
        [DisplayName("Tên người nhận")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TenNguoiNhan { get; set; }
        [DisplayName("SDT nhận")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public int? SDTNguoiNhan { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ nhận")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Tình trạng")]
        [Required(ErrorMessage = "Không đươc để trống!")]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
