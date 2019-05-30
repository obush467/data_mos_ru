namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("data_mos_ru.AO_60562", "GeoData");
        }
        
        public override void Down()
        {
            AddColumn("data_mos_ru.AO_60562", "GeoData", c => c.Geography());
        }
    }
}
