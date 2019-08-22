namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data_7612", "ObjectName", c => c.String(maxLength: 1000));
            DropColumn("dbo.Data_7612", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Data_7612", "Name", c => c.String(maxLength: 1000));
            DropColumn("dbo.Data_7612", "ObjectName");
        }
    }
}
