namespace DoAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        Soluong = c.Int(nullable: false, identity: true),
                        IdSP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Soluong)
                .ForeignKey("dbo.Sanphams", t => t.IdSP, cascadeDelete: true)
                .Index(t => t.IdSP);
            
            CreateTable(
                "dbo.Sanphams",
                c => new
                    {
                        IdSP = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gia = c.Int(nullable: false),
                        Description = c.String(),
                        IdNhasx = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSP)
                .ForeignKey("dbo.Nhasxes", t => t.IdNhasx, cascadeDelete: true)
                .Index(t => t.IdNhasx);
            
            CreateTable(
                "dbo.Nhasxes",
                c => new
                    {
                        IdNhasx = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IdNhasx);
            
            CreateTable(
                "dbo.Taikhoans",
                c => new
                    {
                        IdTK = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.IdTK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GioHangs", "IdSP", "dbo.Sanphams");
            DropForeignKey("dbo.Sanphams", "IdNhasx", "dbo.Nhasxes");
            DropIndex("dbo.Sanphams", new[] { "IdNhasx" });
            DropIndex("dbo.GioHangs", new[] { "IdSP" });
            DropTable("dbo.Taikhoans");
            DropTable("dbo.Nhasxes");
            DropTable("dbo.Sanphams");
            DropTable("dbo.GioHangs");
        }
    }
}
