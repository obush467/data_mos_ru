namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("data_mos_ru.AO_60562", "GeoData_Type", c => c.String());
            AddColumn("data_mos_ru.AO_60562", "GeoData_Coordinates", c => c.Geography());
            AddColumn("data_mos_ru.AO_60562", "GeoData_Сenter", c => c.String());
            DropColumn("data_mos_ru.AO_60562", "GeoData");
        }
        
        public override void Down()
        {
            AddColumn("data_mos_ru.AO_60562", "GeoData", c => c.Geography());
            DropColumn("data_mos_ru.AO_60562", "GeoData_Сenter");
            DropColumn("data_mos_ru.AO_60562", "GeoData_Coordinates");
            DropColumn("data_mos_ru.AO_60562", "GeoData_Type");
        }
    }
}
