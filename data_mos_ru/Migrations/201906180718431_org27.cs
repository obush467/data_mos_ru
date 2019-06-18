namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org27 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            //DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            //DropPrimaryKey("dbo.Organizations");
            //AlterColumn("dbo.Organizations", "Id", c => c.Guid(nullable: false));
            //AddPrimaryKey("dbo.Organizations", "Id");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
            //AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            //DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            //DropPrimaryKey("dbo.Organizations");
            //AlterColumn("dbo.Organizations", "Id", c => c.Guid(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Organizations", "Id");
            //AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
        }
    }
}
