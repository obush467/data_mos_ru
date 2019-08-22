namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data_2624_8684", "ID", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Data_2624_8684", "ID");
        }
    }
}
