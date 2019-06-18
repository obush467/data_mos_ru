namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "OGRN", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "OGRN", c => c.String(maxLength: 13));
        }
    }
}
