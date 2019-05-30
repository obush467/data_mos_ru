namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("data_mos_ru.AO_60562", "GeoData_Type");
            DropColumn("data_mos_ru.AO_60562", "GeoData_Coordinates");
            DropColumn("data_mos_ru.AO_60562", "GeoData_Сenter");
        }
        
        public override void Down()
        {
            AddColumn("data_mos_ru.AO_60562", "GeoData_Сenter", c => c.String());
            AddColumn("data_mos_ru.AO_60562", "GeoData_Coordinates", c => c.Geography());
            AddColumn("data_mos_ru.AO_60562", "GeoData_Type", c => c.String());
        }
    }
}
