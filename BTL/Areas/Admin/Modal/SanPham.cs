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
        [DisplayName("M� S?n Ph?m")]
        public int MaSP { get; set; }

        [DisplayName("M� Danh M?c")]
        public int MaDanhMuc { get; set; }

        [StringLength(50)]
        [DisplayName("T�n S?n Ph?m")]
        [Required(ErrorMessage = " T�n s?n ph?m kh�ng ???c b? tr?ng")]
        public string TenSP { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Gi� S?n Ph?m")]
        [Required(ErrorMessage = " Gi� kh�ng ???c b? tr?ng")]
        public decimal? Gia { get; set; }

        [StringLength(200)]
        [DisplayName("M� T?")]
        public string MoTa { get; set; }

        [StringLength(200)]
        [DisplayName("?nh")]
        [Required(ErrorMessage = " ?nh kh�ng ???c b? tr?ng")]
        public string Anh { get; set; }

        [StringLength(100)]
        [DisplayName("Lo?i")]
        [Required(ErrorMessage = " Lo?i kh�ng ???c b? tr?ng")]
        public string Loai { get; set; }

        [DisplayName("S? L??ng")]
        [Required(ErrorMessage = " Lo?i kh�ng ???c b? tr?ng")]
        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
