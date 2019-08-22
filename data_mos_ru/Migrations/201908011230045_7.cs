namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Data_577_5609", "AmbulanceStationPhone");
        }

        public override void Down()
        {
            AddColumn("dbo.Data_577_5609", "AmbulanceStationPhone", c => c.String());
        }
    }
}
