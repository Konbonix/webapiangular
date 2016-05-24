namespace VRart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nothumbnail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uploads", "ThumbNail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uploads", "ThumbNail", c => c.String(nullable: false));
        }
    }
}
