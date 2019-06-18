namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "data_mos_ru.AO_60562",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.ID);
            
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
                        ID = c.Int(nullable: false, identity: true),
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
                        ID = c.Int(nullable: false, identity: true),
                        data_2624_8684_ID = c.Int(nullable: false),
                        PublicPhone = c.String(),
                        data_2624_8684_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_2624_8684", t => t.data_2624_8684_ID1)
                .Index(t => t.data_2624_8684_ID1);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.publicPhones", "data_2624_8684_ID1", "dbo.data_2624_8684");
            DropForeignKey("data_mos_ru.ResponsiblePersonsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.PersonalAccountsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.FactAddressItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.BankingDetailsItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropForeignKey("data_mos_ru.AdditionalOKVEDItem", "Data_1641_5988_data_1641_5988_ID", "data_mos_ru.data_1641_5988");
            DropIndex("dbo.publicPhones", new[] { "data_2624_8684_ID1" });
            DropIndex("data_mos_ru.ResponsiblePersonsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.PersonalAccountsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.FactAddressItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.BankingDetailsItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
            DropIndex("data_mos_ru.AdditionalOKVEDItem", new[] { "Data_1641_5988_data_1641_5988_ID" });
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
        }
    }
}
