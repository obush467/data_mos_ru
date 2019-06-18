namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _888 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.publicPhones");
           // AlterColumn("dbo.publicPhones", "ID", c => c.Guid(nullable: false, identity: true));
           // AddPrimaryKey("dbo.publicPhones", "ID");
           // DropColumn("dbo.publicPhones", "ID1");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.publicPhones", "ID1", c => c.Guid(nullable: false, identity: true));
           // DropPrimaryKey("dbo.publicPhones");
            //AlterColumn("dbo.publicPhones", "ID", c => c.Int(nullable: false));
           // AddPrimaryKey("dbo.publicPhones", "ID");
        }
    }
}
