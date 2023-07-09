namespace DoAN.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGioHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChitietGioHangs",
                c => new
                    {
                        IdSP = c.Int(nullable: false),
                        IdGioHang = c.Int(nullable: false),
                        SoLuong = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdSP, t.IdGioHang })
                .ForeignKey("dbo.GioHangs", t => t.IdGioHang, cascadeDelete: true)
                .ForeignKey("dbo.Sanphams", t => t.IdSP, cascadeDelete: true)
                .Index(t => t.IdSP)
                .Index(t => t.IdGioHang);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        IdGioHang = c.Int(nullable: false, identity: true),
                        IdUser = c.String(maxLength: 128),
                        ThanhTien = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdGioHang)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .Index(t => t.IdUser);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChitietGioHangs", "IdSP", "dbo.Sanphams");
            DropForeignKey("dbo.Sanphams", "IdNhasx", "dbo.Nhasxes");
            DropForeignKey("dbo.GioHangs", "IdUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChitietGioHangs", "IdGioHang", "dbo.GioHangs");
            DropIndex("dbo.Sanphams", new[] { "IdNhasx" });
            DropIndex("dbo.GioHangs", new[] { "IdUser" });
            DropIndex("dbo.ChitietGioHangs", new[] { "IdGioHang" });
            DropIndex("dbo.ChitietGioHangs", new[] { "IdSP" });
            DropTable("dbo.Nhasxes");
            DropTable("dbo.Sanphams");
            DropTable("dbo.GioHangs");
            DropTable("dbo.ChitietGioHangs");
        }
    }
}
