namespace DoAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sanphams", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sanphams", "ImgUrl");
        }
    }
}
