namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.geoDatas", "AO_60562_ID", "data_mos_ru.AO_60562");
            DropIndex("dbo.geoDatas", new[] { "AO_60562_ID" });
            AddColumn("data_mos_ru.AO_60562", "GeoData_Type", c => c.String());
            AddColumn("data_mos_ru.AO_60562", "GeoData_Coordinates", c => c.Geography());
            AddColumn("data_mos_ru.AO_60562", "GeoData_Сenter", c => c.String());
            DropTable("dbo.geoDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.geoDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Coordinates = c.Geography(),
                        Сenter = c.String(),
                        AO_60562_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("data_mos_ru.AO_60562", "GeoData_Сenter");
            DropColumn("data_mos_ru.AO_60562", "GeoData_Coordinates");
            DropColumn("data_mos_ru.AO_60562", "GeoData_Type");
            CreateIndex("dbo.geoDatas", "AO_60562_ID");
            AddForeignKey("dbo.geoDatas", "AO_60562_ID", "data_mos_ru.AO_60562", "ID");
        }
    }
}
