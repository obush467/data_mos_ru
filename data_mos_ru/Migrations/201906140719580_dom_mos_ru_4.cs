namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dom_mos_ru_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dom_mos_ru.Houses", "UriString", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dom_mos_ru.Houses", "UriString", c => c.String());
        }
    }
}
