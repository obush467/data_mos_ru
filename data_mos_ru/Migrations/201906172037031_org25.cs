namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Human_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                        PositionType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.Human_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .ForeignKey("dbo.PersonPositionTypes", t => t.PositionType_Id)
                .Index(t => t.Human_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.PositionType_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DocumentName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountantGeneralPositions",
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
            
            CreateTable(
                "dbo.DirectorPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Director = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonPositions", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectorPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.AccountantGeneralPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.AccountantGeneralPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropIndex("dbo.DirectorPositions", new[] { "Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "Id" });
            DropIndex("dbo.PersonPositions", new[] { "PositionType_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Human_Id" });
            DropTable("dbo.DirectorPositions");
            DropTable("dbo.AccountantGeneralPositions");
            DropTable("dbo.Documents");
            DropTable("dbo.PersonPositions");
        }
    }
}
