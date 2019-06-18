namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org10 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountantGeneral", newName: "AccountantGeneralPositions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AccountantGeneralPositions", newName: "AccountantGeneral");
        }
    }
}
