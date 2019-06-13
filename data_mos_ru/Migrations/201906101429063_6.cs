namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Email = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailItems", "data_54518_ID", "dbo.data_54518");
            DropIndex("dbo.EmailItems", new[] { "data_54518_ID" });
            DropTable("dbo.EmailItems");
        }
    }
}
