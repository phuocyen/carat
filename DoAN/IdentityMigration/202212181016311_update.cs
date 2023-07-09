namespace DoAN.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GioHangs", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sanphams", "IdNhasx", "dbo.Nhasxes");
            DropForeignKey("dbo.GioHangs", "IdProduct", "dbo.Sanphams");
            DropIndex("dbo.GioHangs", new[] { "UserID" });
            DropIndex("dbo.GioHangs", new[] { "IdProduct" });
        }
        
        public override void Down()
        {
        }
    }
}
