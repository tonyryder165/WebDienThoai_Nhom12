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
    
    public partial class ThongTinCaNhan
    {
        public int id { get; set; }
        public string MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
