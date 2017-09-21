namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("data_mos_ru.MO_geojson");
        }
    }
}
