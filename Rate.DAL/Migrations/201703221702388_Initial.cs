namespace Rate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flicks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Year = c.String(),
                        Rated = c.String(),
                        Released = c.String(),
                        Runtime = c.String(),
                        Genre = c.String(),
                        Director = c.String(),
                        Writer = c.String(),
                        Actors = c.String(),
                        Plot = c.String(),
                        Language = c.String(),
                        Country = c.String(),
                        Poster = c.String(),
                        Metascore = c.String(),
                        ImdbRating = c.String(),
                        Response = c.String(),
                        Type = c.String(),
                        Awards = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ReviewText = c.String(),
                        Flick_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flicks", t => t.Flick_Id)
                .Index(t => t.Flick_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Flick_Id", "dbo.Flicks");
            DropIndex("dbo.Reviews", new[] { "Flick_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Flicks");
        }
    }
}
