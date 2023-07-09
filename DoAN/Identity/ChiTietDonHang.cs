using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using DoAN.Models;
namespace DoAN.Identity
{
    public class ChiTietDonHang
    {
        [Key]
        [Column(Order=0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSP { get; set; }
        [Key]
        [Column(Order=1)]
        public int IdGioHang { get; set; }
        public int? SoLuong { get; set; }
        [ForeignKey("IdSP")]
        public virtual Sanpham SanPham { get; set; }
        [ForeignKey("IdGioHang")]
        public virtual DonHang GioHang { get; set; }
    }
}