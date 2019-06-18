namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShortName = c.String(maxLength: 300),
                        FullName = c.String(maxLength: 1000),
                        OGRN = c.String(maxLength: 13),
                        INN = c.String(maxLength: 12),
                        KPP = c.String(maxLength: 9),
                        UrAddress = c.String(maxLength: 1000),
                        OKPO = c.String(maxLength: 10),
                        OKATO = c.String(maxLength: 11),
                        OKTMTO = c.String(maxLength: 11),
                        OKOGU = c.String(maxLength: 7),
                        OrganizationType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationType_Id)
                .Index(t => t.OrganizationType_Id);
            
            CreateTable(
                "dbo.DirectorPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Director = c.Boolean(nullable: false),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        InstDocument_Id = c.Guid(),
                        Person_Id = c.Guid(),
                        PositionType_Id = c.Guid(),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.InstDocument_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.PersonPositionTypes", t => t.PositionType_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.InstDocument_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.PositionType_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DocumentName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonPositionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PositionType = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShortTypeName = c.String(maxLength: 100),
                        FullTypeName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dom_mos_ru.InfTableRows", "Name", c => c.String(maxLength: 300));
            AlterColumn("dom_mos_ru.InfTableRows", "Value", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "OrganizationType_Id", "dbo.OrganizationTypes");
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.DirectorPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.DirectorPositions", "Person_Id", "dbo.People");
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "PositionType_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Person_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.Organizations", new[] { "OrganizationType_Id" });
            AlterColumn("dom_mos_ru.InfTableRows", "Value", c => c.String());
            AlterColumn("dom_mos_ru.InfTableRows", "Name", c => c.String());
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.PersonPositionTypes");
            DropTable("dbo.People");
            DropTable("dbo.Documents");
            DropTable("dbo.DirectorPositions");
            DropTable("dbo.Organizations");
        }
    }
}
