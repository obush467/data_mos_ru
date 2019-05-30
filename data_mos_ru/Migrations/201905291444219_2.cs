namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "data_mos_ru.AO_60562",
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
            
        }
        
        public override void Down()
        {
            DropTable("data_mos_ru.AO_60562");
        }
    }
}
