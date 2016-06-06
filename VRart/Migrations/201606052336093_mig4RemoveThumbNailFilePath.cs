namespace VRart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4RemoveThumbNailFilePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uploads", "FileType", c => c.String());
            DropColumn("dbo.Uploads", "FilePath");
            DropColumn("dbo.Uploads", "ThumbNail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uploads", "ThumbNail", c => c.String());
            AddColumn("dbo.Uploads", "FilePath", c => c.String(nullable: false));
            DropColumn("dbo.Uploads", "FileType");
        }
    }
}
