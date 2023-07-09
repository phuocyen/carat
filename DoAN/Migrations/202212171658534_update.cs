namespace DoAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GioHangs", "IdSP", "dbo.Sanphams");
            DropIndex("dbo.GioHangs", new[] { "IdSP" });
            DropTable("dbo.GioHangs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        Soluong = c.Int(nullable: false, identity: true),
                        IdSP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Soluong);
            
            CreateIndex("dbo.GioHangs", "IdSP");
            AddForeignKey("dbo.GioHangs", "IdSP", "dbo.Sanphams", "IdSP", cascadeDelete: true);
        }
    }
}
