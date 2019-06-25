namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class eee1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dom_mos_ru.Houses");
            AlterColumn("dom_mos_ru.Houses", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dom_mos_ru.Houses", "ID");
        }

        public override void Down()
        {
            DropPrimaryKey("dom_mos_ru.Houses");
            AlterColumn("dom_mos_ru.Houses", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dom_mos_ru.Houses", "ID");
        }
    }
}
