namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailItems", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.Available_elementItem", "AvailabilityItem_ID", "dbo.AvailabilityItems");
            DropForeignKey("dbo.AvailabilityItems", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems");
            DropForeignKey("dbo.PublicPhoneItem1", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems");
            DropForeignKey("dbo.InstitutionsAddressesItems", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.LicensingAndAccreditationItems", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.PublicPhoneItem2", "data_54518_ID", "dbo.data_54518");
            DropIndex("dbo.EmailItems", new[] { "data_54518_ID" });
            DropIndex("dbo.InstitutionsAddressesItems", new[] { "data_54518_ID" });
            DropIndex("dbo.AvailabilityItems", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("dbo.Available_elementItem", new[] { "AvailabilityItem_ID" });
            DropIndex("dbo.PublicPhoneItem1", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("dbo.LicensingAndAccreditationItems", new[] { "data_54518_ID" });
            DropIndex("dbo.PublicPhoneItem2", new[] { "data_54518_ID" });
            DropColumn("dbo.data_54518", "geoData_Type");
            DropColumn("dbo.data_54518", "geoData_Coordinates");
            DropColumn("dbo.data_54518", "geoData_Сenter");
            DropTable("dbo.EmailItems");
            DropTable("dbo.InstitutionsAddressesItems");
            DropTable("dbo.AvailabilityItems");
            DropTable("dbo.Available_elementItem");
            DropTable("dbo.PublicPhoneItem1");
            DropTable("dbo.LicensingAndAccreditationItems");
            DropTable("dbo.PublicPhoneItem2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PublicPhoneItem2",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PublicPhoneItem1",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        InstitutionsAddressesItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmailItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Email = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.data_54518", "geoData_Сenter", c => c.Geography());
            AddColumn("dbo.data_54518", "geoData_Coordinates", c => c.Geography());
            AddColumn("dbo.data_54518", "geoData_Type", c => c.String(maxLength: 30));
            CreateIndex("dbo.PublicPhoneItem2", "data_54518_ID");
            CreateIndex("dbo.LicensingAndAccreditationItems", "data_54518_ID");
            CreateIndex("dbo.PublicPhoneItem1", "InstitutionsAddressesItem_ID");
            CreateIndex("dbo.Available_elementItem", "AvailabilityItem_ID");
            CreateIndex("dbo.AvailabilityItems", "InstitutionsAddressesItem_ID");
            CreateIndex("dbo.InstitutionsAddressesItems", "data_54518_ID");
            CreateIndex("dbo.EmailItems", "data_54518_ID");
            AddForeignKey("dbo.PublicPhoneItem2", "data_54518_ID", "dbo.data_54518", "ID");
            AddForeignKey("dbo.LicensingAndAccreditationItems", "data_54518_ID", "dbo.data_54518", "ID");
            AddForeignKey("dbo.InstitutionsAddressesItems", "data_54518_ID", "dbo.data_54518", "ID");
            AddForeignKey("dbo.PublicPhoneItem1", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems", "ID");
            AddForeignKey("dbo.AvailabilityItems", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems", "ID");
            AddForeignKey("dbo.Available_elementItem", "AvailabilityItem_ID", "dbo.AvailabilityItems", "ID");
            AddForeignKey("dbo.EmailItems", "data_54518_ID", "dbo.data_54518", "ID");
        }
    }
}
