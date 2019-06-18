namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropPrimaryKey("dbo.Persons");
            AlterColumn("dbo.Persons", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Persons", "Id");
            AddForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropPrimaryKey("dbo.Persons");
            AlterColumn("dbo.Persons", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Persons", "Id");
            AddForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons", "Id");
        }
    }
}
