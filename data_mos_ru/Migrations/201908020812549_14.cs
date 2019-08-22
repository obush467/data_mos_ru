namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data_7361",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    Category = c.String(),
                    CommonName = c.String(),
                    FullName = c.String(),
                    ShortName = c.String(),
                    ChiefOrg = c.String(),
                    ChiefName = c.String(),
                    ChiefPosition = c.String(),
                    ClarificationOfWorkingHours = c.String(),
                    WebSite = c.String(),
                    NumOfSeats = c.Int(nullable: false),
                    geoData_Type = c.String(maxLength: 30),
                    geoData_Coordinates = c.Geography(),
                    geoData_Сenter = c.Geography(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Data_7361_EmailItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_7361_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361", t => t.Data_7361_Id)
                .Index(t => t.Data_7361_Id);

            CreateTable(
                "dbo.Data_7361_FaxItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_7361_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361", t => t.Data_7361_Id)
                .Index(t => t.Data_7361_Id);

            CreateTable(
                "dbo.Data_7361_ObjectAddressItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    PostalCode = c.String(),
                    District = c.String(),
                    Address = c.String(),
                    AdmArea = c.String(),
                    Data_7361_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361", t => t.Data_7361_Id)
                .Index(t => t.Data_7361_Id);

            CreateTable(
                "dbo.Data_7361_AvailabilityItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    available_o = c.String(),
                    available_z = c.String(),
                    available_s = c.String(),
                    available_k = c.String(),
                    Data_7361_ObjectAddressItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361_ObjectAddressItem", t => t.Data_7361_ObjectAddressItem_Id)
                .Index(t => t.Data_7361_ObjectAddressItem_Id);

            CreateTable(
                "dbo.Data_7361_Available_elementItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    available_index = c.String(),
                    Area_mgn = c.String(),
                    Element_mgn = c.String(),
                    available_degree = c.String(),
                    Group_mgn = c.String(),
                    Data_7361_AvailabilityItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361_AvailabilityItem", t => t.Data_7361_AvailabilityItem_Id)
                .Index(t => t.Data_7361_AvailabilityItem_Id);

            CreateTable(
                "dbo.Data_7361_OrgInfoItem",
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
                    Data_7361_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361", t => t.Data_7361_Id)
                .Index(t => t.Data_7361_Id);

            CreateTable(
                "dbo.Data_7361_ChiefPhoneItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_7361_OrgInfoItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361_OrgInfoItem", t => t.Data_7361_OrgInfoItem_Id)
                .Index(t => t.Data_7361_OrgInfoItem_Id);

            CreateTable(
                "dbo.Data_7361_PublicPhoneItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_7361_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361", t => t.Data_7361_Id)
                .Index(t => t.Data_7361_Id);

            CreateTable(
                "dbo.Data_7361_WorkingHoursItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    WorkHours = c.String(),
                    DayWeek = c.String(),
                    Data_7361_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_7361", t => t.Data_7361_Id)
                .Index(t => t.Data_7361_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Data_7361_WorkingHoursItem", "Data_7361_Id", "dbo.Data_7361");
            DropForeignKey("dbo.Data_7361_PublicPhoneItem", "Data_7361_Id", "dbo.Data_7361");
            DropForeignKey("dbo.Data_7361_OrgInfoItem", "Data_7361_Id", "dbo.Data_7361");
            DropForeignKey("dbo.Data_7361_ChiefPhoneItem", "Data_7361_OrgInfoItem_Id", "dbo.Data_7361_OrgInfoItem");
            DropForeignKey("dbo.Data_7361_ObjectAddressItem", "Data_7361_Id", "dbo.Data_7361");
            DropForeignKey("dbo.Data_7361_AvailabilityItem", "Data_7361_ObjectAddressItem_Id", "dbo.Data_7361_ObjectAddressItem");
            DropForeignKey("dbo.Data_7361_Available_elementItem", "Data_7361_AvailabilityItem_Id", "dbo.Data_7361_AvailabilityItem");
            DropForeignKey("dbo.Data_7361_FaxItem", "Data_7361_Id", "dbo.Data_7361");
            DropForeignKey("dbo.Data_7361_EmailItem", "Data_7361_Id", "dbo.Data_7361");
            DropIndex("dbo.Data_7361_WorkingHoursItem", new[] { "Data_7361_Id" });
            DropIndex("dbo.Data_7361_PublicPhoneItem", new[] { "Data_7361_Id" });
            DropIndex("dbo.Data_7361_ChiefPhoneItem", new[] { "Data_7361_OrgInfoItem_Id" });
            DropIndex("dbo.Data_7361_OrgInfoItem", new[] { "Data_7361_Id" });
            DropIndex("dbo.Data_7361_Available_elementItem", new[] { "Data_7361_AvailabilityItem_Id" });
            DropIndex("dbo.Data_7361_AvailabilityItem", new[] { "Data_7361_ObjectAddressItem_Id" });
            DropIndex("dbo.Data_7361_ObjectAddressItem", new[] { "Data_7361_Id" });
            DropIndex("dbo.Data_7361_FaxItem", new[] { "Data_7361_Id" });
            DropIndex("dbo.Data_7361_EmailItem", new[] { "Data_7361_Id" });
            DropTable("dbo.Data_7361_WorkingHoursItem");
            DropTable("dbo.Data_7361_PublicPhoneItem");
            DropTable("dbo.Data_7361_ChiefPhoneItem");
            DropTable("dbo.Data_7361_OrgInfoItem");
            DropTable("dbo.Data_7361_Available_elementItem");
            DropTable("dbo.Data_7361_AvailabilityItem");
            DropTable("dbo.Data_7361_ObjectAddressItem");
            DropTable("dbo.Data_7361_FaxItem");
            DropTable("dbo.Data_7361_EmailItem");
            DropTable("dbo.Data_7361");
        }
    }
}
