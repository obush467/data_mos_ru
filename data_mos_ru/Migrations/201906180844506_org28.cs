namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org28 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.AccountantGeneralPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.AccountantGeneralPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.DirectorPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Human_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
            DropIndex("dbo.PersonPositions", new[] { "PositionType_Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Id" });
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            DropPrimaryKey("dbo.Persons");
            AlterColumn("dbo.Persons", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Persons", "Id");
            DropTable("dbo.PersonPositions");
            DropTable("dbo.Documents");
            DropTable("dbo.AccountantGeneralPositions");
            DropTable("dbo.DirectorPositions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DirectorPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstDocument_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                        Director = c.Boolean(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DocumentName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Human_Id = c.Guid(),
                        Organization_Id1 = c.Guid(),
                        PositionType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropPrimaryKey("dbo.Persons");
            AlterColumn("dbo.Persons", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Persons", "Id");
            CreateIndex("dbo.DirectorPositions", "Organization_Id");
            CreateIndex("dbo.DirectorPositions", "InstDocument_Id");
            CreateIndex("dbo.DirectorPositions", "Id");
            CreateIndex("dbo.AccountantGeneralPositions", "InstDocument_Id");
            CreateIndex("dbo.AccountantGeneralPositions", "Id");
            CreateIndex("dbo.PersonPositions", "PositionType_Id");
            CreateIndex("dbo.PersonPositions", "Organization_Id1");
            CreateIndex("dbo.PersonPositions", "Human_Id");
            AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
            AddForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents", "Id");
            AddForeignKey("dbo.DirectorPositions", "Id", "dbo.PersonPositions", "Id");
            AddForeignKey("dbo.AccountantGeneralPositions", "InstDocument_Id", "dbo.Documents", "Id");
            AddForeignKey("dbo.AccountantGeneralPositions", "Id", "dbo.PersonPositions", "Id");
            AddForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes", "Id");
            AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
            AddForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons", "Id");
        }
    }
}
