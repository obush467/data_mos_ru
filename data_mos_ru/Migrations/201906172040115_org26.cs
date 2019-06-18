namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org26 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id1");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id", newName: "IX_Organization_Id1");
            AddColumn("dbo.DirectorPositions", "InstDocument_Id", c => c.Guid());
            AddColumn("dbo.DirectorPositions", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.DirectorPositions", "InstDocument_Id");
            CreateIndex("dbo.DirectorPositions", "Organization_Id");
            AddForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents", "Id");
            AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropColumn("dbo.DirectorPositions", "Organization_Id");
            DropColumn("dbo.DirectorPositions", "InstDocument_Id");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id1", newName: "IX_Organization_Id");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
        }
    }
}
