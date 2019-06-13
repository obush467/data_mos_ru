namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.publicPhones", "data_2624_8684_ID1", "dbo.data_2624_8684");
            //DropIndex("dbo.publicPhones", new[] { "data_2624_8684_ID1" });
            //DropPrimaryKey("dbo.data_2624_8684");
            //AlterColumn("dbo.data_2624_8684", "ID", c => c.Guid(nullable: false, identity: true));
            //AlterColumn("dbo.publicPhones", "data_2624_8684_ID1", c => c.Guid());
            //AddPrimaryKey("dbo.data_2624_8684", "ID");
            //CreateIndex("dbo.publicPhones", "data_2624_8684_ID1");
            //AddForeignKey("dbo.publicPhones", "data_2624_8684_ID1", "dbo.data_2624_8684", "ID");
        }
        
        public override void Down()
        {
           // DropForeignKey("dbo.publicPhones", "data_2624_8684_ID1", "dbo.data_2624_8684");
            //DropIndex("dbo.publicPhones", new[] { "data_2624_8684_ID1" });
            //DropPrimaryKey("dbo.data_2624_8684");
            //AlterColumn("dbo.publicPhones", "data_2624_8684_ID1", c => c.Int());
            //AlterColumn("dbo.data_2624_8684", "ID", c => c.Int(nullable: false, identity: true));
           // AddPrimaryKey("dbo.data_2624_8684", "ID");
           // CreateIndex("dbo.publicPhones", "data_2624_8684_ID1");
            //AddForeignKey("dbo.publicPhones", "data_2624_8684_ID1", "dbo.data_2624_8684", "ID");
        }
    }
}
