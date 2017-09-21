namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _113 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AO_geojson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(maxLength: 150),
                        OKATO = c.String(maxLength: 150),
                        ABBREV = c.String(maxLength: 150),
                        geometry = c.Geography(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AO_geojson");
        }
    }
}
