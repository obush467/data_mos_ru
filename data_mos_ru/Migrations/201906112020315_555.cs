namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _555 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.publicPhones", new[] { "data_2624_8684_ID1" });
            //DropColumn("dbo.publicPhones", "data_2624_8684_ID");
            //RenameColumn(table: "dbo.publicPhones", name: "data_2624_8684_ID1", newName: "data_2624_8684_ID");
            //AddColumn("dbo.publicPhones", "ParentID", c => c.Guid(nullable: false));
            //AlterColumn("dbo.publicPhones", "data_2624_8684_ID", c => c.Guid());
            //CreateIndex("dbo.publicPhones", "data_2624_8684_ID");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.publicPhones", new[] { "data_2624_8684_ID" });
            //AlterColumn("dbo.publicPhones", "data_2624_8684_ID", c => c.Int(nullable: false));
            //DropColumn("dbo.publicPhones", "ParentID");
            //RenameColumn(table: "dbo.publicPhones", name: "data_2624_8684_ID", newName: "data_2624_8684_ID1");
            //AddColumn("dbo.publicPhones", "data_2624_8684_ID", c => c.Int(nullable: false));
            //CreateIndex("dbo.publicPhones", "data_2624_8684_ID1");
        }
    }
}
