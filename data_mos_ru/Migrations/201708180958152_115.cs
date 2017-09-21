namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _115 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AO_geojson", newSchema: "data_mos_ru");
        }
        
        public override void Down()
        {
            MoveTable(name: "data_mos_ru.AO_geojson", newSchema: "dbo");
        }
    }
}
