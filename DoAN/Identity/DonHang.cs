using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DoAN.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace DoAN.Identity
{
    public class DonHang
    {
        [Key]
        public int IdGioHang { get; set; }
        [Column(TypeName="nvarchar")]
        public string IdUser { get; set; }
        public double ThanhTien { get; set; }
        [ForeignKey("IdUser")]
        public virtual AppUser User { get; set; }
        public DonHang()
        {
            ChitietGioHang = new HashSet<ChiTietDonHang>();
        }
        public virtual ICollection<ChiTietDonHang> ChitietGioHang { get; set; }
    }
}