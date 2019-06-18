namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonPositions", "Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Id" });
            DropColumn("dbo.PersonPositions", "Organization_Id");
            RenameColumn(table: "dbo.PersonPositions", name: "Id", newName: "Organization_Id");
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.PersonPositions", "Organization_Id");
            AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false, identity: true));
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Id");
            AddColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.PersonPositions", "Id");
            AddForeignKey("dbo.PersonPositions", "Id", "dbo.Organizations", "Id");
        }
    }
}
