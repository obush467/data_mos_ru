namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _66 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.publicPhones");
            AddColumn("dbo.publicPhones", "ID1", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.publicPhones", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.publicPhones", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.publicPhones");
            AlterColumn("dbo.publicPhones", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.publicPhones", "ID1");
            AddPrimaryKey("dbo.publicPhones", "ID");
        }
    }
}
