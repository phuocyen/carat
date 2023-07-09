using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DoAN.Models;
namespace DoAN.Identity
{
    public class GioHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "Nvarchar")]
        public string UserID { get; set; }
        public int IdProduct { get; set; }
        [DefaultValue(0)]
        public int Quantity { get; set; }
        [ForeignKey("UserID")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Sanpham SanPham { get; set; }
    }
}