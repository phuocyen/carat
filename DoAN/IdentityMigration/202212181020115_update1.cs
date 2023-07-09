namespace DoAN.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        IdProduct = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Sanphams", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.IdProduct);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GioHangs", "IdProduct", "dbo.Sanphams");
            DropForeignKey("dbo.Sanphams", "IdNhasx", "dbo.Nhasxes");
            DropForeignKey("dbo.GioHangs", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Sanphams", new[] { "IdNhasx" });
            DropIndex("dbo.GioHangs", new[] { "IdProduct" });
            DropIndex("dbo.GioHangs", new[] { "UserID" });

        }
    }
}
