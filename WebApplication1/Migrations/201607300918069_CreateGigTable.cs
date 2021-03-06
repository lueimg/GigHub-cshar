namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artist_Id = c.String(maxLength: 128),
                        Genre_id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
