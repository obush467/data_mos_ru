namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonPositions", "Organization_Id1", c => c.Guid());
            CreateIndex("dbo.PersonPositions", "Organization_Id1");
            AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
            DropColumn("dbo.PersonPositions", "Organization_Id1");
        }
    }
}
