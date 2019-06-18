namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents");
            DropIndex("dbo.DirectorPositions", new[] { "InstDocument_Id" });
            DropColumn("dbo.DirectorPositions", "InstDocument_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DirectorPositions", "InstDocument_Id", c => c.Guid());
            CreateIndex("dbo.DirectorPositions", "InstDocument_Id");
            AddForeignKey("dbo.DirectorPositions", "InstDocument_Id", "dbo.Documents", "Id");
        }
    }
}
