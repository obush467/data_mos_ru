namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Data_7361_EmailItem", "Email", c => c.String());
            AddColumn("dbo.Data_7361_FaxItem", "Fax", c => c.String());
            AddColumn("dbo.Data_7361_ChiefPhoneItem", "ChiefPhone", c => c.String());
            AddColumn("dbo.Data_7361_PublicPhoneItem", "PublicPhone", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Data_7361_PublicPhoneItem", "PublicPhone");
            DropColumn("dbo.Data_7361_ChiefPhoneItem", "ChiefPhone");
            DropColumn("dbo.Data_7361_FaxItem", "Fax");
            DropColumn("dbo.Data_7361_EmailItem", "Email");
        }
    }
}
