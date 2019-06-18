namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org22 : DbMigration
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
                        OGRN = c.String(maxLength: 30),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "OrganizationType_Id", "dbo.OrganizationTypes");
            DropIndex("dbo.Organizations", new[] { "OrganizationType_Id" });
            DropTable("dbo.Organizations");
        }
    }
}
