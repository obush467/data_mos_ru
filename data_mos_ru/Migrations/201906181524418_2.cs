namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("data_mos_ru.EmailItem", new[] { "data_54518_ID" });
            DropIndex("data_mos_ru.InstitutionsAddressesItem", new[] { "data_54518_ID" });
            DropIndex("data_mos_ru.AvailabilityItem", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("data_mos_ru.Available_elementItem", new[] { "AvailabilityItem_ID" });
            DropIndex("data_mos_ru.PublicPhoneItem1", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("data_mos_ru.LicensingAndAccreditationItem", new[] { "data_54518_ID" });
            DropIndex("data_mos_ru.PublicPhoneItem2", new[] { "data_54518_ID" });
            CreateTable(
                "dbo.Data_1181_7382",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Global_id = c.Int(nullable: false),
                    WebSite = c.String(),
                    Category = c.String(),
                    CommonName = c.String(),
                    FullName = c.String(),
                    ShortName = c.String(),
                    ChiefName = c.String(),
                    ChiefPosition = c.String(),
                    GeoData_Type = c.String(maxLength: 30),
                    GeoData_Coordinates = c.Geography(),
                    GeoData_Сenter = c.Geography(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.FaxItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            CreateTable(
                "dbo.ObjectAddressItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    PostalCode = c.String(),
                    District = c.String(),
                    Address = c.String(),
                    AdmArea = c.String(),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            CreateTable(
                "dbo.OrgInfoItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    OGRN = c.String(),
                    ChiefName = c.String(),
                    INN = c.String(),
                    KPP = c.String(),
                    LegalAddress = c.String(),
                    FullName = c.String(),
                    ChiefPosition = c.String(),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            CreateTable(
                "dbo.ChiefPhoneItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    ChiefPhone = c.String(),
                    OrgInfoItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrgInfoItems", t => t.OrgInfoItem_Id)
                .Index(t => t.OrgInfoItem_Id);

            CreateTable(
                "dbo.PublicPhoneItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            CreateTable(
                "dbo.WorkingHoursItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    WorkHours = c.String(),
                    DayWeek = c.String(),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            /* CreateTable(
                 "data_mos_ru.data_54518",
                 c => new
                     {
                         Id = c.Guid(nullable: false, identity: true),
                         Global_id = c.Int(nullable: false),
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
                         GeoData_Type = c.String(maxLength: 30),
                         GeoData_Coordinates = c.Geography(),
                         GeoData_Сenter = c.Geography(),
                     })
                 .PrimaryKey(t => t.Id);*/

            AddColumn("data_mos_ru.EmailItem", "Data_1181_7382_Id", c => c.Guid());
            AddColumn("data_mos_ru.AvailabilityItem", "ObjectAddressItem_Id", c => c.Guid());
            CreateIndex("data_mos_ru.EmailItem", "Data_1181_7382_Id");
            CreateIndex("data_mos_ru.EmailItem", "Data_54518_Id");
            CreateIndex("data_mos_ru.AvailabilityItem", "ObjectAddressItem_Id");
            CreateIndex("data_mos_ru.AvailabilityItem", "InstitutionsAddressesItem_Id");
            CreateIndex("data_mos_ru.Available_elementItem", "AvailabilityItem_Id");
            CreateIndex("data_mos_ru.InstitutionsAddressesItem", "Data_54518_Id");
            CreateIndex("data_mos_ru.PublicPhoneItem1", "InstitutionsAddressesItem_Id");
            CreateIndex("data_mos_ru.LicensingAndAccreditationItem", "Data_54518_Id");
            CreateIndex("data_mos_ru.PublicPhoneItem2", "Data_54518_Id");
            AddForeignKey("data_mos_ru.EmailItem", "Data_1181_7382_Id", "dbo.Data_1181_7382", "Id");
            AddForeignKey("data_mos_ru.AvailabilityItem", "ObjectAddressItem_Id", "dbo.ObjectAddressItems", "Id");
            //DropTable("data_mos_ru.data_54518");
        }

        public override void Down()
        {
            /* CreateTable(
                 "data_mos_ru.data_54518",
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
                 .PrimaryKey(t => t.ID);*/

            DropForeignKey("dbo.WorkingHoursItems", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.PublicPhoneItems", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.OrgInfoItems", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.ChiefPhoneItems", "OrgInfoItem_Id", "dbo.OrgInfoItems");
            DropForeignKey("dbo.ObjectAddressItems", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("data_mos_ru.AvailabilityItem", "ObjectAddressItem_Id", "dbo.ObjectAddressItems");
            DropForeignKey("dbo.FaxItems", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("data_mos_ru.EmailItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropIndex("data_mos_ru.PublicPhoneItem2", new[] { "Data_54518_Id" });
            DropIndex("data_mos_ru.LicensingAndAccreditationItem", new[] { "Data_54518_Id" });
            DropIndex("data_mos_ru.PublicPhoneItem1", new[] { "InstitutionsAddressesItem_Id" });
            DropIndex("data_mos_ru.InstitutionsAddressesItem", new[] { "Data_54518_Id" });
            DropIndex("dbo.WorkingHoursItems", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.PublicPhoneItems", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.ChiefPhoneItems", new[] { "OrgInfoItem_Id" });
            DropIndex("dbo.OrgInfoItems", new[] { "Data_1181_7382_Id" });
            DropIndex("data_mos_ru.Available_elementItem", new[] { "AvailabilityItem_Id" });
            DropIndex("data_mos_ru.AvailabilityItem", new[] { "InstitutionsAddressesItem_Id" });
            DropIndex("data_mos_ru.AvailabilityItem", new[] { "ObjectAddressItem_Id" });
            DropIndex("dbo.ObjectAddressItems", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.FaxItems", new[] { "Data_1181_7382_Id" });
            DropIndex("data_mos_ru.EmailItem", new[] { "Data_54518_Id" });
            DropIndex("data_mos_ru.EmailItem", new[] { "Data_1181_7382_Id" });
            DropColumn("data_mos_ru.AvailabilityItem", "ObjectAddressItem_Id");
            DropColumn("data_mos_ru.EmailItem", "Data_1181_7382_Id");
            DropTable("data_mos_ru.data_54518");
            DropTable("dbo.WorkingHoursItems");
            DropTable("dbo.PublicPhoneItems");
            DropTable("dbo.ChiefPhoneItems");
            DropTable("dbo.OrgInfoItems");
            DropTable("dbo.ObjectAddressItems");
            DropTable("dbo.FaxItems");
            DropTable("dbo.Data_1181_7382");
            CreateIndex("data_mos_ru.PublicPhoneItem2", "data_54518_ID");
            CreateIndex("data_mos_ru.LicensingAndAccreditationItem", "data_54518_ID");
            CreateIndex("data_mos_ru.PublicPhoneItem1", "InstitutionsAddressesItem_ID");
            CreateIndex("data_mos_ru.Available_elementItem", "AvailabilityItem_ID");
            CreateIndex("data_mos_ru.AvailabilityItem", "InstitutionsAddressesItem_ID");
            CreateIndex("data_mos_ru.InstitutionsAddressesItem", "data_54518_ID");
            CreateIndex("data_mos_ru.EmailItem", "data_54518_ID");
        }
    }
}
