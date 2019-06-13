namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.data_54518", "geoData_Type", c => c.String(maxLength: 30));
            AddColumn("dbo.data_54518", "geoData_Coordinates", c => c.Geography());
            AddColumn("dbo.data_54518", "geoData_Сenter", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.data_54518", "geoData_Сenter");
            DropColumn("dbo.data_54518", "geoData_Coordinates");
            DropColumn("dbo.data_54518", "geoData_Type");
        }
    }
}
