namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.geoDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Coordinates = c.Geography(),
                        Сenter = c.String(),
                        AO_60562_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("data_mos_ru.AO_60562", t => t.AO_60562_ID)
                .Index(t => t.AO_60562_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.geoDatas", "AO_60562_ID", "data_mos_ru.AO_60562");
            DropIndex("dbo.geoDatas", new[] { "AO_60562_ID" });
            DropTable("dbo.geoDatas");
        }
    }
}
