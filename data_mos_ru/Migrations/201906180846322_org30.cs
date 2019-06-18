namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DirectorPositions", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.DirectorPositions", "Organization_Id");
            AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            DropColumn("dbo.DirectorPositions", "Organization_Id");
        }
    }
}
