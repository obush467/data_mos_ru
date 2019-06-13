namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _55454 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.publicPhones", "ParentID_ID", "dbo.data_2624_8684_1");
            DropIndex("dbo.publicPhones", new[] { "ParentID_ID" });
            RenameColumn(table: "dbo.publicPhones", name: "ParentID_ID", newName: "ParentID");
            AlterColumn("dbo.publicPhones", "ParentID", c => c.Guid(nullable: false));
            CreateIndex("dbo.publicPhones", "ParentID");
            AddForeignKey("dbo.publicPhones", "ParentID", "dbo.data_2624_8684_1", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.publicPhones", "ParentID", "dbo.data_2624_8684_1");
            DropIndex("dbo.publicPhones", new[] { "ParentID" });
            AlterColumn("dbo.publicPhones", "ParentID", c => c.Guid());
            RenameColumn(table: "dbo.publicPhones", name: "ParentID", newName: "ParentID_ID");
            CreateIndex("dbo.publicPhones", "ParentID_ID");
            AddForeignKey("dbo.publicPhones", "ParentID_ID", "dbo.data_2624_8684_1", "ID");
        }
    }
}
