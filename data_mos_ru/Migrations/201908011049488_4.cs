namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Data_577_5609_PublicPhoneItem", "PublicPhone");
        }

        public override void Down()
        {
            AddColumn("dbo.Data_577_5609_PublicPhoneItem", "PublicPhone", c => c.String());
        }
    }
}
