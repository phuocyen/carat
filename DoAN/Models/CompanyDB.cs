using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace DoAN.Models
{
    public class CompanyDB: DbContext
    {
        public CompanyDB() : base("MyConnection") { }
        public DbSet<Nhasx> Nhasx { get; set; }
        public DbSet<Sanpham> Sanpham { get; set; }      
        }
    }
