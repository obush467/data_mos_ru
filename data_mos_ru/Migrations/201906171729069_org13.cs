namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class org13 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn("dbo.PersonPositions", "Organization_Id1","Organization_Id");
            //CreateIndex("dbo.PersonPositions", "Organization_Id1");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
           // DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
           // DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
           // DropColumn("dbo.PersonPositions", "Organization_Id1");
        }
    }
}
