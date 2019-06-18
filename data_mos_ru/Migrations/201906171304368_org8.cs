namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectorPositions",
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
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.DirectorPositions", "Id", "dbo.PersonPositions");
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Id" });
            DropTable("dbo.DirectorPositions");
        }
    }
}
