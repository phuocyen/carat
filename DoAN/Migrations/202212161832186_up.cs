namespace DoAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GioHang", newName: "GioHangs");
            RenameTable(name: "dbo.Sanpham", newName: "Sanphams");
            RenameTable(name: "dbo.Nhasx", newName: "Nhasxes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idUser);
            
            CreateTable(
                "dbo.Taikhoan",
                c => new
                    {
                        IdTK = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.IdTK);
            
            RenameTable(name: "dbo.Nhasxes", newName: "Nhasx");
            RenameTable(name: "dbo.Sanphams", newName: "Sanpham");
            RenameTable(name: "dbo.GioHangs", newName: "GioHang");
        }
    }
}
