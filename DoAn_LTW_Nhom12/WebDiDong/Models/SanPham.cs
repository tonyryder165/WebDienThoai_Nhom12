//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDiDong.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public int MaSanPham { get; set; }
        public Nullable<int> MaLoaiSanPham { get; set; }
        public Nullable<int> MaNhaSanXuat { get; set; }
        public string TenSanPham { get; set; }
        public string CauHinh { get; set; }
        public string HinhChinh { get; set; }
        public HttpPostedFileBase HinHChinhFile { get; set; }

        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public string Hinh4 { get; set; }
        public Nullable<int> Gia { get; set; }
        public Nullable<int> SoLuongDaBan { get; set; }
        public Nullable<int> LuotView { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
