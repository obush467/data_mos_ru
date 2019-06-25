namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class qqq1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dom_mos_ru.UPRs");
            AlterColumn("dom_mos_ru.UPRs", "ID", c => c.Guid(nullable: false));
            AlterColumn("dom_mos_ru.UPRs", "Value", c => c.String(maxLength: 500));
            AlterColumn("dom_mos_ru.UPRs", "Label", c => c.String(maxLength: 500));
            AlterColumn("dom_mos_ru.UPRs", "Url", c => c.String(maxLength: 300));
            AlterColumn("dom_mos_ru.UPRs", "Section", c => c.String(maxLength: 30));
            AddPrimaryKey("dom_mos_ru.UPRs", "ID");
        }

        public override void Down()
        {
            DropPrimaryKey("dom_mos_ru.UPRs");
            AlterColumn("dom_mos_ru.UPRs", "Section", c => c.String());
            AlterColumn("dom_mos_ru.UPRs", "Url", c => c.String());
            AlterColumn("dom_mos_ru.UPRs", "Label", c => c.String());
            AlterColumn("dom_mos_ru.UPRs", "Value", c => c.String());
            AlterColumn("dom_mos_ru.UPRs", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dom_mos_ru.UPRs", "ID");
        }
    }
}
