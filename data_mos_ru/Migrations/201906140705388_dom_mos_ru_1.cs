namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class dom_mos_ru_1 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.UPRs", newSchema: "dom_mos_ru");
        }
        
        public override void Down()
        {
            MoveTable(name: "dom_mos_ru.UPRs", newSchema: "dbo");
        }
    }
}
