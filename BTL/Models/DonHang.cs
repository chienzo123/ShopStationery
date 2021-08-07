namespace BTL.Models
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
        public int MaDH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenNguoiNhan { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public int? SDTNguoiNhan { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
