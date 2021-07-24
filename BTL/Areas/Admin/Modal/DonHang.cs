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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đơn Hàng")]
        public int MaDH { get; set; }

        [DisplayName("Tên Người Nhận")]
        [StringLength(100)]
        public string TenNguoiNhan { get; set; }
        [DisplayName("Số điện thoại nhận")]
        public int? SDTNguoiNhan { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ Nhận")]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
