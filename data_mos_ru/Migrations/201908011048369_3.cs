namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data_577_5609_PublicPhoneItem", "PublicPhone", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Data_577_5609_PublicPhoneItem", "PublicPhone");
        }
    }
}
