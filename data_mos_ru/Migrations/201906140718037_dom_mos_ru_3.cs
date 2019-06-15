namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class dom_mos_ru_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dom_mos_ru.Houses", "UriString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dom_mos_ru.Houses", "UriString");
        }
    }
}
