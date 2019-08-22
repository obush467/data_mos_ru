namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "data_mos_ru.AO_60562",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Global_ID = c.Int(),
                    Adm_Area = c.String(maxLength: 1000),
                    UNOM = c.Int(),
                    VID = c.String(maxLength: 1000),
                    TDOC = c.String(maxLength: 1000),
                    NDOC = c.String(maxLength: 1000),
                    DDOC = c.DateTime(),
                    NREG = c.Int(),
                    DREG = c.DateTime(),
                    ADDRESS = c.String(maxLength: 1000),
                    P1 = c.String(maxLength: 200),
                    P2 = c.String(maxLength: 200),
                    P3 = c.String(maxLength: 200),
                    P4 = c.String(maxLength: 200),
                    P5 = c.String(maxLength: 200),
                    P6 = c.String(maxLength: 200),
                    P7 = c.String(maxLength: 200),
                    P90 = c.String(maxLength: 200),
                    P91 = c.String(maxLength: 200),
                    L1_TYPE = c.String(maxLength: 200),
                    L1_VALUE = c.String(maxLength: 200),
                    L2_TYPE = c.String(maxLength: 200),
                    L2_VALUE = c.String(maxLength: 200),
                    L3_TYPE = c.String(maxLength: 200),
                    L3_VALUE = c.String(maxLength: 200),
                    L4_TYPE = c.String(maxLength: 200),
                    L4_VALUE = c.String(maxLength: 200),
                    L5_TYPE = c.String(maxLength: 200),
                    L5_VALUE = c.String(maxLength: 200),
                    DISTRICT = c.String(maxLength: 200),
                    N_FIAS = c.Guid(),
                    D_FIAS = c.DateTime(),
                    KLADR = c.String(maxLength: 30),
                    ADR_TYPE = c.String(maxLength: 40),
                    GeoData_Type = c.String(maxLength: 30),
                    GeoData_Coordinates = c.Geography(),
                    GeoData_Сenter = c.Geography(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "data_mos_ru.AO_geojson",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    NAME = c.String(maxLength: 150),
                    OKATO = c.String(maxLength: 150),
                    ABBREV = c.String(maxLength: 150),
                    geometry = c.Geography(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "data_mos_ru.AO",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    AdmArea = c.String(maxLength: 1000),
                    system_object_id = c.String(maxLength: 100),
                    UNOM = c.Int(),
                    KAD_RN = c.Int(),
                    KAD_KV = c.Int(),
                    KAD_ZU = c.Int(),
                    DMT = c.String(maxLength: 40),
                    KRT = c.String(maxLength: 40),
                    VLD = c.String(maxLength: 40),
                    STRT = c.String(maxLength: 40),
                    SOOR = c.String(maxLength: 40),
                    TDOC = c.String(maxLength: 500),
                    NDOC = c.String(maxLength: 500),
                    DDOC = c.DateTime(),
                    NREG = c.Int(),
                    DREG = c.DateTime(),
                    VYVAD = c.String(maxLength: 1000),
                    ADRES = c.String(maxLength: 2000),
                    geoData = c.Geography(),
                })
                .PrimaryKey(t => t.id);

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
                "dbo.Data_1181_7382_EmailItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            CreateTable(
                "dbo.Data_1181_7382_FaxItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Data_1181_7382_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382", t => t.Data_1181_7382_Id)
                .Index(t => t.Data_1181_7382_Id);

            CreateTable(
                "dbo.Data_1181_7382_ObjectAddressItem",
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
                "dbo.Data_1181_7382_AvailabilityItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    available_z = c.String(),
                    available_o = c.String(),
                    available_s = c.String(),
                    available_k = c.String(),
                    Data_1181_7382_ObjectAddressItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382_ObjectAddressItem", t => t.Data_1181_7382_ObjectAddressItem_Id)
                .Index(t => t.Data_1181_7382_ObjectAddressItem_Id);

            CreateTable(
                "dbo.Data_1181_7382_OrgInfoItem",
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
                "dbo.Data_1181_7382_PublicPhoneItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    OwnerID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Data_1181_7382_WorkingHoursItem",
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

            CreateTable(
                "data_mos_ru.data_1641_5988",
                c => new
                {
                    data_1641_5988_ID = c.Guid(nullable: false, identity: true),
                    ID = c.String(),
                    global_id = c.Int(nullable: false),
                    OrgType = c.String(),
                    DateBegin = c.String(),
                    DateEnd = c.String(),
                    INN = c.String(),
                    KPP = c.String(),
                    INN_KPP = c.String(),
                    FullName = c.String(),
                    ShortName = c.String(),
                    OGRN = c.String(),
                    Territory = c.String(),
                    LegalAddressMGK = c.String(),
                    DepartmentCode = c.String(),
                    LegalAddressEGRUL = c.String(),
                    Verification = c.String(),
                    OKOPF = c.String(),
                    OKATO = c.String(),
                    OKPO = c.String(),
                    UNK = c.String(),
                    OKVED = c.String(),
                    OGS = c.String(),
                    OKTMO = c.String(),
                    OKFS = c.String(),
                    OKOGU = c.String(),
                })
                .PrimaryKey(t => t.data_1641_5988_ID);

            CreateTable(
                "data_mos_ru.Data_1641_5988_AdditionalOKVEDItem",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    AdditionalOKVED = c.String(),
                    Data_1641_5988_data_1641_5988_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_1641_5988", t => t.Data_1641_5988_data_1641_5988_ID)
                .Index(t => t.Data_1641_5988_data_1641_5988_ID);

            CreateTable(
                "data_mos_ru.Data_1641_5988_BankingDetailsItem",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    SettlementAccount = c.String(),
                    BIK = c.String(),
                    NameBank = c.String(),
                    Data_1641_5988_data_1641_5988_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_1641_5988", t => t.Data_1641_5988_data_1641_5988_ID)
                .Index(t => t.Data_1641_5988_data_1641_5988_ID);

            CreateTable(
                "data_mos_ru.Data_1641_5988_FactAddressItem",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    FactAddress = c.String(),
                    Data_1641_5988_data_1641_5988_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_1641_5988", t => t.Data_1641_5988_data_1641_5988_ID)
                .Index(t => t.Data_1641_5988_data_1641_5988_ID);

            CreateTable(
                "data_mos_ru.Data_1641_5988_PersonalAccountsItem",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    Account = c.String(),
                    OpenDate = c.String(),
                    Data_1641_5988_data_1641_5988_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_1641_5988", t => t.Data_1641_5988_data_1641_5988_ID)
                .Index(t => t.Data_1641_5988_data_1641_5988_ID);

            CreateTable(
                "data_mos_ru.Data_1641_5988_ResponsiblePersonsItem",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    FIO = c.String(),
                    TypePosition = c.String(),
                    NamePosition = c.String(),
                    Data_1641_5988_data_1641_5988_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_1641_5988", t => t.Data_1641_5988_data_1641_5988_ID)
                .Index(t => t.Data_1641_5988_data_1641_5988_ID);

            CreateTable(
                "dbo.Data_2624_8684",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(),
                    Name = c.String(maxLength: 1000),
                    AdmArea = c.String(maxLength: 1000),
                    District = c.String(maxLength: 1000),
                    Address = c.String(maxLength: 1000),
                    MetroStation = c.String(maxLength: 1000),
                    MetroLine = c.String(maxLength: 1000),
                    WebSite = c.String(maxLength: 1000),
                    geoData_Type = c.String(maxLength: 30),
                    geoData_Coordinates = c.Geography(),
                    geoData_Сenter = c.Geography(),
                    Longitude_WGS84 = c.Double(),
                    Latitude_WGS84 = c.Double(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Data_2624_8684_publicPhone",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    ParentID = c.Guid(nullable: false),
                    PublicPhone = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Data_2624_8684", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ParentID);

            CreateTable(
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
                .PrimaryKey(t => t.Id);

            CreateTable(
                "data_mos_ru.Data_54518_EmailItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Email = c.String(maxLength: 50),
                    Data_54518_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.data_54518", t => t.Data_54518_Id)
                .Index(t => t.Data_54518_Id);

            CreateTable(
                "data_mos_ru.Data_54518_InstitutionsAddressesItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    ChiefName = c.String(maxLength: 150),
                    ChiefPosition = c.String(maxLength: 100),
                    FullName = c.String(maxLength: 1000),
                    District = c.String(maxLength: 100),
                    Address = c.String(maxLength: 1000),
                    WebSite = c.String(maxLength: 100),
                    AdmArea = c.String(maxLength: 100),
                    Data_54518_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.data_54518", t => t.Data_54518_Id)
                .Index(t => t.Data_54518_Id);

            CreateTable(
                "data_mos_ru.Data_54518_AvailabilityItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Available_o = c.String(),
                    Available_z = c.String(),
                    Available_s = c.String(),
                    Available_k = c.String(),
                    Data_54518_InstitutionsAddressesItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.Data_54518_InstitutionsAddressesItem", t => t.Data_54518_InstitutionsAddressesItem_Id)
                .Index(t => t.Data_54518_InstitutionsAddressesItem_Id);

            CreateTable(
                "data_mos_ru.Data_54518_Available_elementItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Available_index = c.String(),
                    Area_mgn = c.String(),
                    Element_mgn = c.String(),
                    Available_degree = c.String(),
                    Group_mgn = c.String(),
                    Data_54518_AvailabilityItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.Data_54518_AvailabilityItem", t => t.Data_54518_AvailabilityItem_Id)
                .Index(t => t.Data_54518_AvailabilityItem_Id);

            CreateTable(
                "data_mos_ru.Data_54518_PublicPhoneItem1",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    PublicPhone = c.String(maxLength: 30),
                    Data_54518_InstitutionsAddressesItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.Data_54518_InstitutionsAddressesItem", t => t.Data_54518_InstitutionsAddressesItem_Id)
                .Index(t => t.Data_54518_InstitutionsAddressesItem_Id);

            CreateTable(
                "data_mos_ru.Data_54518_LicensingAndAccreditationItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    LicenseSeries = c.String(),
                    LicenseNumber = c.String(),
                    LicenseExpires = c.String(),
                    AccreditationAvailability = c.String(),
                    LicenseAvailability = c.String(),
                    Data_54518_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.data_54518", t => t.Data_54518_Id)
                .Index(t => t.Data_54518_Id);

            CreateTable(
                "data_mos_ru.Data_54518_PublicPhoneItem2",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    PublicPhone = c.String(maxLength: 30),
                    Data_54518_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("data_mos_ru.data_54518", t => t.Data_54518_Id)
                .Index(t => t.Data_54518_Id);

            CreateTable(
                "dbo.Data_577_5609",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    FullName = c.String(),
                    ShortName = c.String(),
                    Category = c.String(),
                    ChiefName = c.String(),
                    ChiefPosition = c.String(),
                    ChiefGender = c.String(),
                    CloseFlag = c.String(),
                    BedSpace = c.String(),
                    PaidServiceInfo = c.String(),
                    Specialization = c.String(),
                    geoData_Type = c.String(maxLength: 30),
                    geoData_Coordinates = c.Geography(),
                    geoData_Сenter = c.Geography(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Data_577_5609_EmailItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Email = c.String(),
                    Data_577_5609_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609", t => t.Data_577_5609_Id)
                .Index(t => t.Data_577_5609_Id);

            CreateTable(
                "dbo.Data_577_5609_FaxItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Fax = c.String(),
                    Data_577_5609_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609", t => t.Data_577_5609_Id)
                .Index(t => t.Data_577_5609_Id);

            CreateTable(
                "dbo.Data_577_5609_ObjectAddressItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    PostalCode = c.String(),
                    AdmArea = c.String(),
                    District = c.String(),
                    Address = c.String(),
                    Extrainfo = c.String(),
                    Data_577_5609_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609", t => t.Data_577_5609_Id)
                .Index(t => t.Data_577_5609_Id);

            CreateTable(
                "dbo.Data_577_5609_AvailabilityItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    available_z = c.String(),
                    available_o = c.String(),
                    available_s = c.String(),
                    available_k = c.String(),
                    Data_577_5609_ObjectAddressItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609_ObjectAddressItem", t => t.Data_577_5609_ObjectAddressItem_Id)
                .Index(t => t.Data_577_5609_ObjectAddressItem_Id);

            CreateTable(
                "dbo.Data_577_5609_OrgInfoItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    OGRN = c.String(),
                    ChiefPosition = c.String(),
                    ChiefName = c.String(),
                    INN = c.String(),
                    KPP = c.String(),
                    LegalAddress = c.String(),
                    FullName = c.String(),
                    ChiefGender = c.String(),
                    Data_577_5609_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609", t => t.Data_577_5609_Id)
                .Index(t => t.Data_577_5609_Id);

            CreateTable(
                "dbo.Data_577_5609_WorkingHoursItem",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    WorkHours = c.String(),
                    DayWeek = c.String(),
                    Data_577_5609_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609", t => t.Data_577_5609_Id)
                .Index(t => t.Data_577_5609_Id);

            CreateTable(
                "dom_mos_ru.Houses",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    UriString = c.String(maxLength: 100),
                    UPRUriString = c.String(maxLength: 100),
                    Address = c.String(),
                    AdmArea = c.String(),
                    YearOfConstruction = c.Int(),
                    Series = c.String(),
                    StoreysCount = c.Int(),
                    TotalArea = c.String(),
                    TotalAreaResidentialPremises = c.String(),
                    HouseList_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.HouseLists", t => t.HouseList_ID, cascadeDelete: true)
                .Index(t => t.HouseList_ID);

            CreateTable(
                "dom_mos_ru.HouseLists",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    Name = c.String(),
                    UPRsite_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.UPRsites", t => t.UPRsite_ID)
                .Index(t => t.UPRsite_ID);

            CreateTable(
                "dom_mos_ru.InfTableRows",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    Name = c.String(maxLength: 300),
                    Value = c.String(maxLength: 1000),
                    UPRsite_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.UPRsites", t => t.UPRsite_ID)
                .Index(t => t.UPRsite_ID);

            CreateTable(
                "data_mos_ru.MO_geojson",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    NAME = c.String(maxLength: 150),
                    OKATO = c.String(maxLength: 150),
                    OKTMO = c.String(maxLength: 150),
                    NAME_AO = c.String(maxLength: 150),
                    OKATO_AO = c.String(maxLength: 150),
                    TYPE_MO = c.String(maxLength: 150),
                    ABBREV_AO = c.String(maxLength: 150),
                    geometry = c.Geography(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "data_mos_ru.MO_Type",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Number = c.Int(),
                    global_id = c.Int(nullable: false),
                    MO_Type_C = c.String(maxLength: 40),
                    MO_Type_N = c.String(maxLength: 40),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "data_mos_ru.MO",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    system_object_id = c.String(),
                    MO_Code = c.String(maxLength: 40),
                    MO_Name = c.String(maxLength: 40),
                    MO_Trans = c.String(maxLength: 1000),
                    MO_Type = c.String(maxLength: 1000),
                    MO_TE = c.String(maxLength: 1000),
                    MO_OKTMO = c.String(maxLength: 1000),
                    geoData = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "data_mos_ru.OMK002_2013_1",
                c => new
                {
                    ID = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    Kod = c.String(maxLength: 40),
                    Name = c.String(maxLength: 40),
                    Latin_Name = c.String(maxLength: 1000),
                    Type = c.String(maxLength: 1000),
                    Kod_okato = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "data_mos_ru.OMK002_2013_2",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    Kod = c.String(maxLength: 40),
                    Name = c.String(maxLength: 40),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "data_mos_ru.TM_Type",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    TM_TYPEC = c.String(),
                    TM_TYPEN = c.String(maxLength: 2000),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "data_mos_ru.TMED",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    TM_COMM = c.String(maxLength: 2000),
                    TM_NAMES = c.String(maxLength: 2000),
                    TM_TRANS = c.String(maxLength: 2000),
                    TM_TYPE = c.String(maxLength: 2000),
                    TM_TE = c.String(maxLength: 2000),
                    TM_KLADR = c.String(maxLength: 2000),
                    TM_NAMEF = c.String(maxLength: 2000),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "data_mos_ru.TM",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    TM_CODE = c.String(maxLength: 2000),
                    TM_NAMEF = c.String(maxLength: 2000),
                    TM_NAMES = c.String(maxLength: 2000),
                    TM_TRANS = c.String(maxLength: 2000),
                    TM_TYPE = c.String(maxLength: 2000),
                    TM_TE = c.String(maxLength: 2000),
                    TM_KLADR = c.String(maxLength: 2000),
                    TM_STAT = c.String(maxLength: 2000),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "data_mos_ru.UM_Type",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    system_object_id = c.String(maxLength: 2000),
                    UM_STAT = c.String(maxLength: 2000),
                    UM_TYPEC = c.String(maxLength: 2000),
                    UM_TYPEN = c.String(maxLength: 2000),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "data_mos_ru.UM",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    global_id = c.Int(nullable: false),
                    UM_CODE = c.String(maxLength: 2000),
                    system_object_id = c.String(maxLength: 2000),
                    UM_NAMEF = c.String(maxLength: 2000),
                    UM_NAMES = c.String(maxLength: 2000),
                    UM_TRANS = c.String(maxLength: 2000),
                    UM_TYPE = c.String(maxLength: 2000),
                    UM_TM = c.String(maxLength: 2000),
                    UM_TE = c.String(maxLength: 2000),
                    UM_KLADR = c.String(maxLength: 2000),
                    geoData = c.String(maxLength: 2000),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dom_mos_ru.UPRs",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    Value = c.String(maxLength: 500),
                    Label = c.String(maxLength: 500),
                    Url = c.String(maxLength: 300),
                    Section = c.String(maxLength: 30),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dom_mos_ru.UPRsites",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    Name = c.String(),
                    Uri = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.CourseInstructor",
                c => new
                {
                    ID1 = c.Guid(nullable: false),
                    ID2 = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.ID1, t.ID2 })
                .ForeignKey("dbo.Data_1181_7382", t => t.ID1, cascadeDelete: true)
                .ForeignKey("dbo.Data_1181_7382_PublicPhoneItem", t => t.ID2, cascadeDelete: true)
                .Index(t => t.ID1)
                .Index(t => t.ID2);

        }

        public override void Down()
        {
            DropForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists");
            DropForeignKey("dbo.Data_577_5609_WorkingHoursItem", "Data_577_5609_Id", "dbo.Data_577_5609");
            DropForeignKey("dbo.Data_577_5609_OrgInfoItem", "Data_577_5609_Id", "dbo.Data_577_5609");
            DropForeignKey("dbo.Data_577_5609_ObjectAddressItem", "Data_577_5609_Id", "dbo.Data_577_5609");
            DropForeignKey("dbo.Data_577_5609_AvailabilityItem", "Data_577_5609_ObjectAddressItem_Id", "dbo.Data_577_5609_ObjectAddressItem");
            DropForeignKey("dbo.Data_577_5609_FaxItem", "Data_577_5609_Id", "dbo.Data_577_5609");
            DropForeignKey("dbo.Data_577_5609_EmailItem", "Data_577_5609_Id", "dbo.Data_577_5609");
            DropForeignKey("data_mos_ru.Data_54518_PublicPhoneItem2", "Data_54518_Id", "data_mos_ru.data_54518");
            DropForeignKey("data_mos_ru.Data_54518_LicensingAndAccreditationItem", "Data_54518_Id", "data_mos_ru.data_54518");
            DropForeignKey("data_mos_ru.Data_54518_InstitutionsAddressesItem", "Data_54518_Id", "data_mos_ru.data_54518");
            DropForeignKey("data_mos_ru.Data_54518_PublicPhoneItem1", "Data_54518_InstitutionsAddressesItem_Id", "data_mos_ru.Data_54518_InstitutionsAddressesItem");
            DropForeignKey("data_mos_ru.Data_54518_AvailabilityItem", "Data_54518_InstitutionsAddressesItem_Id", "data_mos_ru.Data_54518_InstitutionsAddressesItem");
            DropForeignKey("data_mos_ru.Data_54518_Available_elementItem", "Data_54518_AvailabilityItem_Id", "data_mos_ru.Data_54518_AvailabilityItem");
            DropForeignKey("data_mos_ru.Data_54518_EmailItem", "Data_54518_Id", "data_mos_ru.data_54518");
            DropForeignKey("dbo.Data_2624_8684_publicPhone", "ParentID", "dbo.Data_2624_8684");
            DropForeignKey("data_mos_ru.Data_1641_5988_ResponsiblePersonsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.Data_1641_5988_PersonalAccountsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.Data_1641_5988_FactAddressItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.Data_1641_5988_BankingDetailsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.Data_1641_5988_AdditionalOKVEDItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("dbo.Data_1181_7382_WorkingHoursItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.CourseInstructor", "ID2", "dbo.Data_1181_7382_PublicPhoneItem");
            DropForeignKey("dbo.CourseInstructor", "ID1", "dbo.Data_1181_7382");
            DropForeignKey("dbo.Data_1181_7382_OrgInfoItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.Data_1181_7382_ObjectAddressItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.Data_1181_7382_AvailabilityItem", "Data_1181_7382_ObjectAddressItem_Id", "dbo.Data_1181_7382_ObjectAddressItem");
            DropForeignKey("dbo.Data_1181_7382_FaxItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropForeignKey("dbo.Data_1181_7382_EmailItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropIndex("dbo.CourseInstructor", new[] { "ID2" });
            DropIndex("dbo.CourseInstructor", new[] { "ID1" });
            DropIndex("dom_mos_ru.InfTableRows", new[] { "UPRsite_ID" });
            DropIndex("dom_mos_ru.HouseLists", new[] { "UPRsite_ID" });
            DropIndex("dom_mos_ru.Houses", new[] { "HouseList_ID" });
            DropIndex("dbo.Data_577_5609_WorkingHoursItem", new[] { "Data_577_5609_Id" });
            DropIndex("dbo.Data_577_5609_OrgInfoItem", new[] { "Data_577_5609_Id" });
            DropIndex("dbo.Data_577_5609_AvailabilityItem", new[] { "Data_577_5609_ObjectAddressItem_Id" });
            DropIndex("dbo.Data_577_5609_ObjectAddressItem", new[] { "Data_577_5609_Id" });
            DropIndex("dbo.Data_577_5609_FaxItem", new[] { "Data_577_5609_Id" });
            DropIndex("dbo.Data_577_5609_EmailItem", new[] { "Data_577_5609_Id" });
            DropIndex("data_mos_ru.Data_54518_PublicPhoneItem2", new[] { "Data_54518_Id" });
            DropIndex("data_mos_ru.Data_54518_LicensingAndAccreditationItem", new[] { "Data_54518_Id" });
            DropIndex("data_mos_ru.Data_54518_PublicPhoneItem1", new[] { "Data_54518_InstitutionsAddressesItem_Id" });
            DropIndex("data_mos_ru.Data_54518_Available_elementItem", new[] { "Data_54518_AvailabilityItem_Id" });
            DropIndex("data_mos_ru.Data_54518_AvailabilityItem", new[] { "Data_54518_InstitutionsAddressesItem_Id" });
            DropIndex("data_mos_ru.Data_54518_InstitutionsAddressesItem", new[] { "Data_54518_Id" });
            DropIndex("data_mos_ru.Data_54518_EmailItem", new[] { "Data_54518_Id" });
            DropIndex("dbo.Data_2624_8684_publicPhone", new[] { "ParentID" });
            DropIndex("data_mos_ru.Data_1641_5988_ResponsiblePersonsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.Data_1641_5988_PersonalAccountsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.Data_1641_5988_FactAddressItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.Data_1641_5988_BankingDetailsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.Data_1641_5988_AdditionalOKVEDItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("dbo.Data_1181_7382_WorkingHoursItem", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.Data_1181_7382_OrgInfoItem", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.Data_1181_7382_AvailabilityItem", new[] { "Data_1181_7382_ObjectAddressItem_Id" });
            DropIndex("dbo.Data_1181_7382_ObjectAddressItem", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.Data_1181_7382_FaxItem", new[] { "Data_1181_7382_Id" });
            DropIndex("dbo.Data_1181_7382_EmailItem", new[] { "Data_1181_7382_Id" });
            DropTable("dbo.CourseInstructor");
            DropTable("dom_mos_ru.UPRsites");
            DropTable("dom_mos_ru.UPRs");
            DropTable("data_mos_ru.UM");
            DropTable("data_mos_ru.UM_Type");
            DropTable("data_mos_ru.TM");
            DropTable("data_mos_ru.TMED");
            DropTable("data_mos_ru.TM_Type");
            DropTable("data_mos_ru.OMK002_2013_2");
            DropTable("data_mos_ru.OMK002_2013_1");
            DropTable("data_mos_ru.MO");
            DropTable("data_mos_ru.MO_Type");
            DropTable("data_mos_ru.MO_geojson");
            DropTable("dom_mos_ru.InfTableRows");
            DropTable("dom_mos_ru.HouseLists");
            DropTable("dom_mos_ru.Houses");
            DropTable("dbo.Data_577_5609_WorkingHoursItem");
            DropTable("dbo.Data_577_5609_OrgInfoItem");
            DropTable("dbo.Data_577_5609_AvailabilityItem");
            DropTable("dbo.Data_577_5609_ObjectAddressItem");
            DropTable("dbo.Data_577_5609_FaxItem");
            DropTable("dbo.Data_577_5609_EmailItem");
            DropTable("dbo.Data_577_5609");
            DropTable("data_mos_ru.Data_54518_PublicPhoneItem2");
            DropTable("data_mos_ru.Data_54518_LicensingAndAccreditationItem");
            DropTable("data_mos_ru.Data_54518_PublicPhoneItem1");
            DropTable("data_mos_ru.Data_54518_Available_elementItem");
            DropTable("data_mos_ru.Data_54518_AvailabilityItem");
            DropTable("data_mos_ru.Data_54518_InstitutionsAddressesItem");
            DropTable("data_mos_ru.Data_54518_EmailItem");
            DropTable("data_mos_ru.data_54518");
            DropTable("dbo.Data_2624_8684_publicPhone");
            DropTable("dbo.Data_2624_8684");
            DropTable("data_mos_ru.Data_1641_5988_ResponsiblePersonsItem");
            DropTable("data_mos_ru.Data_1641_5988_PersonalAccountsItem");
            DropTable("data_mos_ru.Data_1641_5988_FactAddressItem");
            DropTable("data_mos_ru.Data_1641_5988_BankingDetailsItem");
            DropTable("data_mos_ru.Data_1641_5988_AdditionalOKVEDItem");
            DropTable("data_mos_ru.data_1641_5988");
            DropTable("dbo.Data_1181_7382_WorkingHoursItem");
            DropTable("dbo.Data_1181_7382_PublicPhoneItem");
            DropTable("dbo.Data_1181_7382_OrgInfoItem");
            DropTable("dbo.Data_1181_7382_AvailabilityItem");
            DropTable("dbo.Data_1181_7382_ObjectAddressItem");
            DropTable("dbo.Data_1181_7382_FaxItem");
            DropTable("dbo.Data_1181_7382_EmailItem");
            DropTable("dbo.Data_1181_7382");
            DropTable("data_mos_ru.AO");
            DropTable("data_mos_ru.AO_geojson");
            DropTable("data_mos_ru.AO_60562");
        }
    }
}
