namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org2 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.PersonPositions", newName: "DirectorPositions");
            //DropIndex("dbo.DirectorPositions", new[] { "Person_Id" });
            //DropIndex("dbo.DirectorPositions", new[] { "PositionType_Id" });
            //DropPrimaryKey("dbo.DirectorPositions");
            CreateTable(
                "dbo.PersonPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Person_Id = c.Guid(),
                        PositionType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Person_Id)
                .Index(t => t.PositionType_Id);

        }
        
        public override void Down()
        {

        }
    }
}
