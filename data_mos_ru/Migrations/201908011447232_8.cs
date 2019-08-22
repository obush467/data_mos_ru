namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Data_2624_8684_publicPhone", "ParentID", "dbo.Data_2624_8684");
            DropPrimaryKey("dbo.Data_2624_8684");
            AddColumn("dbo.Data_2624_8684", "Data_2624_8684_ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Data_2624_8684", "Data_2624_8684_ID");
            AddForeignKey("dbo.Data_2624_8684_publicPhone", "ParentID", "dbo.Data_2624_8684", "Data_2624_8684_ID", cascadeDelete: true);
            DropColumn("dbo.Data_2624_8684", "ID");
        }

        public override void Down()
        {
            AddColumn("dbo.Data_2624_8684", "ID", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.Data_2624_8684_publicPhone", "ParentID", "dbo.Data_2624_8684");
            DropPrimaryKey("dbo.Data_2624_8684");
            DropColumn("dbo.Data_2624_8684", "Data_2624_8684_ID");
            AddPrimaryKey("dbo.Data_2624_8684", "ID");
            AddForeignKey("dbo.Data_2624_8684_publicPhone", "ParentID", "dbo.Data_2624_8684", "ID", cascadeDelete: true);
        }
    }
}
