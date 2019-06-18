namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeaderPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.LeaderPositions", "InstDocument_Id", "dbo.Documents");
            DropIndex("dbo.LeaderPositions", new[] { "Id" });
            DropIndex("dbo.LeaderPositions", new[] { "InstDocument_Id" });
            CreateTable(
                "dbo.AccountantGeneral",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstDocument_Id = c.Guid(),
                        AccountantGeneral = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonPositions", t => t.Id)
                .ForeignKey("dbo.Documents", t => t.InstDocument_Id)
                .Index(t => t.Id)
                .Index(t => t.InstDocument_Id);
            
            DropTable("dbo.LeaderPositions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LeaderPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstDocument_Id = c.Guid(),
                        Director = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AccountantGeneral", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.AccountantGeneral", "Id", "dbo.PersonPositions");
            DropIndex("dbo.AccountantGeneral", new[] { "InstDocument_Id" });
            DropIndex("dbo.AccountantGeneral", new[] { "Id" });
            DropTable("dbo.AccountantGeneral");
            CreateIndex("dbo.LeaderPositions", "InstDocument_Id");
            CreateIndex("dbo.LeaderPositions", "Id");
            AddForeignKey("dbo.LeaderPositions", "InstDocument_Id", "dbo.Documents", "Id");
            AddForeignKey("dbo.LeaderPositions", "Id", "dbo.PersonPositions", "Id");
        }
    }
}
