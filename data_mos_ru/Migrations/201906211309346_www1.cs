namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class www1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dom_mos_ru.Houses", "UPRUriString", c => c.String(maxLength: 100));
        }

        public override void Down()
        {
            DropColumn("dom_mos_ru.Houses", "UPRUriString");
        }
    }
}
