namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class старт : DbMigration
    {
        public override void Up()
        {
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
            DropTable("data_mos_ru.AO");
            DropTable("data_mos_ru.AO_geojson");
        }
    }
}
