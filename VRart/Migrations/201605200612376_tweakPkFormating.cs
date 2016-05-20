namespace VRart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweakPkFormating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumUrl = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        UploadId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Created = c.DateTime(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UploadId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uploads", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Uploads", new[] { "AlbumId" });
            DropTable("dbo.Uploads");
            DropTable("dbo.Albums");
        }
    }
}
