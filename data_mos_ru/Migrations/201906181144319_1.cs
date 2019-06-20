namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _1 : DbMigration
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
                        Organization_Id = c.Guid(nullable: false),
                        Human_Id = c.Guid(),
                        PositionType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.Human_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.PersonPositionTypes", t => t.PositionType_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.Human_Id)
                .Index(t => t.PositionType_Id);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
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
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                        ADR_TYPE = c.String(maxLength: 4000),
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
                        AdmArea = c.String(maxLength: 4000),
                        system_object_id = c.String(maxLength: 4000),
                        UNOM = c.Int(),
                        KAD_RN = c.Int(),
                        KAD_KV = c.Int(),
                        KAD_ZU = c.Int(),
                        DMT = c.String(maxLength: 4000),
                        KRT = c.String(maxLength: 4000),
                        VLD = c.String(maxLength: 4000),
                        STRT = c.String(maxLength: 4000),
                        SOOR = c.String(maxLength: 4000),
                        TDOC = c.String(maxLength: 4000),
                        NDOC = c.String(maxLength: 4000),
                        DDOC = c.DateTime(),
                        NREG = c.Int(),
                        DREG = c.DateTime(),
                        VYVAD = c.String(maxLength: 4000),
                        ADRES = c.String(maxLength: 4000),
                        geoData = c.Geography(),
                    })
                .PrimaryKey(t => t.id);
            
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
                "data_mos_ru.AdditionalOKVEDItem",
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
                "data_mos_ru.BankingDetailsItem",
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
                "data_mos_ru.FactAddressItem",
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
                "data_mos_ru.PersonalAccountsItem",
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
                "data_mos_ru.ResponsiblePersonsItem",
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
                "dbo.data_2624_8684",
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
                "dbo.publicPhones",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ParentID = c.Guid(nullable: false),
                        PublicPhone = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_2624_8684", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ParentID);
            
            CreateTable(
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "data_mos_ru.EmailItem",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "data_mos_ru.InstitutionsAddressesItem",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ChiefName = c.String(maxLength: 150),
                        ChiefPosition = c.String(maxLength: 100),
                        FullName = c.String(maxLength: 1000),
                        District = c.String(maxLength: 100),
                        Address = c.String(maxLength: 1000),
                        WebSite = c.String(maxLength: 100),
                        AdmArea = c.String(maxLength: 100),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "data_mos_ru.AvailabilityItem",
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
                .ForeignKey("data_mos_ru.InstitutionsAddressesItem", t => t.InstitutionsAddressesItem_ID)
                .Index(t => t.InstitutionsAddressesItem_ID);
            
            CreateTable(
                "data_mos_ru.Available_elementItem",
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
                .ForeignKey("data_mos_ru.AvailabilityItem", t => t.AvailabilityItem_ID)
                .Index(t => t.AvailabilityItem_ID);
            
            CreateTable(
                "data_mos_ru.PublicPhoneItem1",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(maxLength: 30),
                        InstitutionsAddressesItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.InstitutionsAddressesItem", t => t.InstitutionsAddressesItem_ID)
                .Index(t => t.InstitutionsAddressesItem_ID);
            
            CreateTable(
                "data_mos_ru.LicensingAndAccreditationItem",
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
                .ForeignKey("data_mos_ru.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "data_mos_ru.PublicPhoneItem2",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(maxLength: 30),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "dom_mos_ru.Houses",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        UriString = c.String(maxLength: 100),
                        Address = c.String(),
                        AdmArea = c.String(),
                        YearOfConstruction = c.Int(),
                        Series = c.String(),
                        StoreysCount = c.Int(),
                        TotalArea = c.String(),
                        TotalAreaResidentialPremises = c.String(),
                        HouseList_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.HouseLists", t => t.HouseList_ID)
                .Index(t => t.HouseList_ID);
            
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
                        MO_Type_C = c.String(maxLength: 4000),
                        MO_Type_N = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.MO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        system_object_id = c.String(),
                        MO_Code = c.String(maxLength: 4000),
                        MO_Name = c.String(maxLength: 4000),
                        MO_Trans = c.String(maxLength: 4000),
                        MO_Type = c.String(maxLength: 4000),
                        MO_TE = c.String(maxLength: 4000),
                        MO_OKTMO = c.String(maxLength: 4000),
                        geoData = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "data_mos_ru.OMK002_2013_1",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        Kod = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                        Latin_Name = c.String(maxLength: 4000),
                        Type = c.String(maxLength: 4000),
                        Kod_okato = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "data_mos_ru.OMK002_2013_2",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        Kod = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.TM_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        TM_TYPEC = c.String(),
                        TM_TYPEN = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "data_mos_ru.TMED",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        TM_COMM = c.String(maxLength: 4000),
                        TM_NAMES = c.String(maxLength: 4000),
                        TM_TRANS = c.String(maxLength: 4000),
                        TM_TYPE = c.String(maxLength: 4000),
                        TM_TE = c.String(maxLength: 4000),
                        TM_KLADR = c.String(maxLength: 4000),
                        TM_NAMEF = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.TM",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        TM_CODE = c.String(maxLength: 4000),
                        TM_NAMEF = c.String(maxLength: 4000),
                        TM_NAMES = c.String(maxLength: 4000),
                        TM_TRANS = c.String(maxLength: 4000),
                        TM_TYPE = c.String(maxLength: 4000),
                        TM_TE = c.String(maxLength: 4000),
                        TM_KLADR = c.String(maxLength: 4000),
                        TM_STAT = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.UM_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        system_object_id = c.String(maxLength: 4000),
                        UM_STAT = c.String(maxLength: 4000),
                        UM_TYPEC = c.String(maxLength: 4000),
                        UM_TYPEN = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "data_mos_ru.UM",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        UM_CODE = c.String(maxLength: 4000),
                        system_object_id = c.String(maxLength: 4000),
                        UM_NAMEF = c.String(maxLength: 4000),
                        UM_NAMES = c.String(maxLength: 4000),
                        UM_TRANS = c.String(maxLength: 4000),
                        UM_TYPE = c.String(maxLength: 4000),
                        UM_TM = c.String(maxLength: 4000),
                        UM_TE = c.String(maxLength: 4000),
                        UM_KLADR = c.String(maxLength: 4000),
                        geoData = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dom_mos_ru.UPRs",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Value = c.String(),
                        Label = c.String(),
                        Url = c.String(),
                        Section = c.String(),
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
                        InstDocument_Id = c.Guid(),
                        Director = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonPositions", t => t.Id)
                .ForeignKey("dbo.Documents", t => t.InstDocument_Id)
                .Index(t => t.Id)
                .Index(t => t.InstDocument_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.DirectorPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dbo.AccountantGeneralPositions", "InstDocument_Id", "dbo.Documents");
            DropForeignKey("dbo.AccountantGeneralPositions", "Id", "dbo.PersonPositions");
            DropForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists");
            DropForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropForeignKey("data_mos_ru.PublicPhoneItem2", "data_54518_ID", "data_mos_ru.data_54518");
            DropForeignKey("data_mos_ru.LicensingAndAccreditationItem", "data_54518_ID", "data_mos_ru.data_54518");
            DropForeignKey("data_mos_ru.InstitutionsAddressesItem", "data_54518_ID", "data_mos_ru.data_54518");
            DropForeignKey("data_mos_ru.PublicPhoneItem1", "InstitutionsAddressesItem_ID", "data_mos_ru.InstitutionsAddressesItem");
            DropForeignKey("data_mos_ru.AvailabilityItem", "InstitutionsAddressesItem_ID", "data_mos_ru.InstitutionsAddressesItem");
            DropForeignKey("data_mos_ru.Available_elementItem", "AvailabilityItem_ID", "data_mos_ru.AvailabilityItem");
            DropForeignKey("data_mos_ru.EmailItem", "data_54518_ID", "data_mos_ru.data_54518");
            DropForeignKey("dbo.publicPhones", "ParentID", "dbo.data_2624_8684");
            DropForeignKey("data_mos_ru.ResponsiblePersonsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.PersonalAccountsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.FactAddressItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.BankingDetailsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.AdditionalOKVEDItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("dbo.Organizations", "OrganizationType_Id", "dbo.OrganizationTypes");
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "InstDocument_Id" });
            DropIndex("dbo.AccountantGeneralPositions", new[] { "Id" });
            DropIndex("dom_mos_ru.HouseLists", new[] { "UPRsite_ID" });
            DropIndex("dom_mos_ru.InfTableRows", new[] { "UPRsite_ID" });
            DropIndex("dom_mos_ru.Houses", new[] { "HouseList_ID" });
            DropIndex("data_mos_ru.PublicPhoneItem2", new[] { "data_54518_ID" });
            DropIndex("data_mos_ru.LicensingAndAccreditationItem", new[] { "data_54518_ID" });
            DropIndex("data_mos_ru.PublicPhoneItem1", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("data_mos_ru.Available_elementItem", new[] { "AvailabilityItem_ID" });
            DropIndex("data_mos_ru.AvailabilityItem", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("data_mos_ru.InstitutionsAddressesItem", new[] { "data_54518_ID" });
            DropIndex("data_mos_ru.EmailItem", new[] { "data_54518_ID" });
            DropIndex("dbo.publicPhones", new[] { "ParentID" });
            DropIndex("data_mos_ru.ResponsiblePersonsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.PersonalAccountsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.FactAddressItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.BankingDetailsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.AdditionalOKVEDItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("dbo.Organizations", new[] { "OrganizationType_Id" });
            DropIndex("dbo.PersonPositions", new[] { "PositionType_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Human_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            DropTable("dbo.DirectorPositions");
            DropTable("dbo.AccountantGeneralPositions");
            DropTable("dom_mos_ru.HouseLists");
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
            DropTable("dom_mos_ru.Houses");
            DropTable("data_mos_ru.PublicPhoneItem2");
            DropTable("data_mos_ru.LicensingAndAccreditationItem");
            DropTable("data_mos_ru.PublicPhoneItem1");
            DropTable("data_mos_ru.Available_elementItem");
            DropTable("data_mos_ru.AvailabilityItem");
            DropTable("data_mos_ru.InstitutionsAddressesItem");
            DropTable("data_mos_ru.EmailItem");
            DropTable("data_mos_ru.data_54518");
            DropTable("dbo.publicPhones");
            DropTable("dbo.data_2624_8684");
            DropTable("data_mos_ru.ResponsiblePersonsItem");
            DropTable("data_mos_ru.PersonalAccountsItem");
            DropTable("data_mos_ru.FactAddressItem");
            DropTable("data_mos_ru.BankingDetailsItem");
            DropTable("data_mos_ru.AdditionalOKVEDItem");
            DropTable("data_mos_ru.data_1641_5988");
            DropTable("data_mos_ru.AO");
            DropTable("data_mos_ru.AO_geojson");
            DropTable("data_mos_ru.AO_60562");
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.PersonPositionTypes");
            DropTable("dbo.Organizations");
            DropTable("dbo.Documents");
            DropTable("dbo.Persons");
            DropTable("dbo.PersonPositions");
        }
    }
}
