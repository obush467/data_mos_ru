namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaderPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstDocument_Id = c.Guid(),
                        Director = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonPositions", t => t.Id)
                .ForeignKey("dbo.Documents", t => t.InstDocument_Id)
                .Index(t => t.Id)
                .Index(t => t.InstDocument_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaderPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.LeaderPositions", "Id", "dbo.PersonPositions");
            DropIndex("dbo.LeaderPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.LeaderPositions", new[] { "Id" });
            DropTable("dbo.LeaderPositions");
        }
    }
}
