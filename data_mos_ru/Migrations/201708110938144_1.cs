namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "data_mos_ru.AO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        AdmArea = c.String(),
                        system_object_id = c.String(),
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
                "data_mos_ru.MO_Type",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(),
                        Cells_global_id = c.Int(nullable: false),
                        Cells_MO_Type_C = c.String(maxLength: 4000),
                        Cells_MO_Type_N = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.MO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        system_object_id = c.String(),
                        MO_Code = c.String(),
                        MO_Name = c.String(),
                        MO_Trans = c.String(),
                        MO_Type = c.String(),
                        MO_TE = c.String(),
                        MO_OKTMO = c.String(),
                        geoData = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "data_mos_ru.OMK002_2013_1",
                c => new
                    {
                        global_id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Cells_global_id = c.Int(nullable: false),
                        Cells_Kod = c.String(maxLength: 4000),
                        Cells_Name = c.String(maxLength: 4000),
                        Cells_Latin_Name = c.String(maxLength: 4000),
                        Cells_Type = c.String(maxLength: 4000),
                        Cells_Kod_okato = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.global_id);
            
            CreateTable(
                "data_mos_ru.OMK002_2013_2",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Cells_global_id = c.Int(nullable: false),
                        Cells_Kod = c.String(),
                        Cells_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.TM_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        system_object_id = c.String(maxLength: 4000),
                        TM_TYPEC = c.String(maxLength: 4000),
                        TM_TYPEN = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "data_mos_ru.TMED",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Cells_global_id = c.Int(nullable: false),
                        Cells_TM_COMM = c.String(),
                        Cells_TM_NAMES = c.String(),
                        Cells_TM_TRANS = c.String(),
                        Cells_TM_TYPE = c.String(),
                        Cells_TM_TE = c.String(),
                        Cells_TM_KLADR = c.String(),
                        Cells_TM_NAMEF = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.TM",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Cells_global_id = c.Int(nullable: false),
                        Cells_TM_CODE = c.String(),
                        Cells_TM_NAMEF = c.String(),
                        Cells_TM_NAMES = c.String(),
                        Cells_TM_TRANS = c.String(),
                        Cells_TM_TYPE = c.String(),
                        Cells_TM_TE = c.String(),
                        Cells_TM_KLADR = c.String(),
                        Cells_TM_STAT = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "data_mos_ru.UM_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        system_object_id = c.String(),
                        UM_STAT = c.String(),
                        UM_TYPEC = c.String(),
                        UM_TYPEN = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "data_mos_ru.UM",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        global_id = c.Int(nullable: false),
                        UM_CODE = c.String(),
                        system_object_id = c.String(),
                        UM_NAMEF = c.String(),
                        UM_NAMES = c.String(),
                        UM_TRANS = c.String(),
                        UM_TYPE = c.String(),
                        UM_TM = c.String(),
                        UM_TE = c.String(),
                        UM_KLADR = c.String(),
                        geoData = c.String(),
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
            DropTable("data_mos_ru.AO");
        }
    }
}
