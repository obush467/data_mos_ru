namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org15 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            //DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            //RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
            //RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id1", newName: "IX_Organization_Id");
            //DropColumn("dbo.DirectorPositions", "Organization_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.DirectorPositions", "Organization_Id", c => c.Guid());
            //RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id", newName: "IX_Organization_Id1");
           //RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id1");
            //CreateIndex("dbo.DirectorPositions", "Organization_Id");
            //AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
