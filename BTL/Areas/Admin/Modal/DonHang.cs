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
        public int MaDH { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Ng??i Nh?n")]
        public string TenNguoiNhan { get; set; }
        [DisplayName("S? ?i?n tho?i nh?n")]
        public int? SDTNguoiNhan { get; set; }

        [StringLength(100)]
        [DisplayName("??a ch? nh?n")]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Tình tr?ng")]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
