namespace VRart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uploads", "FileName", c => c.String());
            AddColumn("dbo.Uploads", "FilePath", c => c.String());
            AlterColumn("dbo.Uploads", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uploads", "Title", c => c.String());
            DropColumn("dbo.Uploads", "FilePath");
            DropColumn("dbo.Uploads", "FileName");
        }
    }
}
