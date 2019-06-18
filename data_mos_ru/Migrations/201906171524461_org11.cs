namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PersonPositions", name: "Person_Id", newName: "Human_Id");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Person_Id", newName: "IX_Human_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Human_Id", newName: "IX_Person_Id");
            RenameColumn(table: "dbo.PersonPositions", name: "Human_Id", newName: "Person_Id");
        }
    }
}
