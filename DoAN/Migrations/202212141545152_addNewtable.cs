namespace DoAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewtable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GioHangs", newName: "GioHang");
            RenameTable(name: "dbo.Sanphams", newName: "Sanpham");
            RenameTable(name: "dbo.Nhasxes", newName: "Nhasx");
            RenameTable(name: "dbo.Taikhoans", newName: "Taikhoan");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Taikhoan", newName: "Taikhoans");
            RenameTable(name: "dbo.Nhasx", newName: "Nhasxes");
            RenameTable(name: "dbo.Sanpham", newName: "Sanphams");
            RenameTable(name: "dbo.GioHang", newName: "GioHangs");
        }
    }
}
