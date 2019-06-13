namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.data_54518",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        KPP = c.String(),
                        OGRN = c.String(),
                        LegalOrganization = c.String(),
                        Subordination = c.String(),
                        ChiefName = c.String(),
                        LegalAddress = c.String(),
                        WebSite = c.String(),
                        EducationPrograms = c.String(),
                        ReorganizationStatus = c.String(),
                        IDEKIS = c.Int(nullable: false),
                        FullName = c.String(),
                        ShortName = c.String(),
                        INN = c.String(),
                        geoData_Type = c.String(maxLength: 30),
                        geoData_Coordinates = c.Geography(),
                        geoData_Сenter = c.Geography(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmailItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Email = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "dbo.InstitutionsAddressesItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ChiefName = c.String(),
                        ChiefPosition = c.String(),
                        FullName = c.String(),
                        District = c.String(),
                        Address = c.String(),
                        WebSite = c.String(),
                        AdmArea = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "dbo.AvailabilityItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        available_o = c.String(),
                        available_z = c.String(),
                        available_s = c.String(),
                        available_k = c.String(),
                        InstitutionsAddressesItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstitutionsAddressesItems", t => t.InstitutionsAddressesItem_ID)
                .Index(t => t.InstitutionsAddressesItem_ID);
            
            CreateTable(
                "dbo.Available_elementItem",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        available_index = c.String(),
                        Area_mgn = c.String(),
                        Element_mgn = c.String(),
                        available_degree = c.String(),
                        Group_mgn = c.String(),
                        AvailabilityItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AvailabilityItems", t => t.AvailabilityItem_ID)
                .Index(t => t.AvailabilityItem_ID);
            
            CreateTable(
                "dbo.PublicPhoneItem1",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        InstitutionsAddressesItem_ID = c.Guid(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstitutionsAddressesItems", t => t.InstitutionsAddressesItem_ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.InstitutionsAddressesItem_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "dbo.LicensingAndAccreditationItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        LicenseSeries = c.String(),
                        LicenseNumber = c.String(),
                        LicenseExpires = c.String(),
                        AccreditationAvailability = c.String(),
                        LicenseAvailability = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicPhoneItem1", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.LicensingAndAccreditationItems", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.InstitutionsAddressesItems", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.PublicPhoneItem1", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems");
            DropForeignKey("dbo.AvailabilityItems", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems");
            DropForeignKey("dbo.Available_elementItem", "AvailabilityItem_ID", "dbo.AvailabilityItems");
            DropForeignKey("dbo.EmailItems", "data_54518_ID", "dbo.data_54518");
            DropIndex("dbo.LicensingAndAccreditationItems", new[] { "data_54518_ID" });
            DropIndex("dbo.PublicPhoneItem1", new[] { "data_54518_ID" });
            DropIndex("dbo.PublicPhoneItem1", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("dbo.Available_elementItem", new[] { "AvailabilityItem_ID" });
            DropIndex("dbo.AvailabilityItems", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("dbo.InstitutionsAddressesItems", new[] { "data_54518_ID" });
            DropIndex("dbo.EmailItems", new[] { "data_54518_ID" });
            DropTable("dbo.LicensingAndAccreditationItems");
            DropTable("dbo.PublicPhoneItem1");
            DropTable("dbo.Available_elementItem");
            DropTable("dbo.AvailabilityItems");
            DropTable("dbo.InstitutionsAddressesItems");
            DropTable("dbo.EmailItems");
            DropTable("dbo.data_54518");
        }
    }
}
