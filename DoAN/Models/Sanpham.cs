using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAN.Models
{
    public class Sanpham
    {
        [Key]
        public int IdSP { get; set; }
        public string Name { get; set; }
        public int Gia { get; set; }
        public string Description { get; set; }
        public int IdNhasx { get; set; }
        public string ImgUrl { get; set; }
        public virtual Nhasx Nhasx { get; set; }
    }
}