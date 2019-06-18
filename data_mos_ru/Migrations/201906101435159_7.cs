namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicPhoneItem2",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicPhoneItem2", "data_54518_ID", "dbo.data_54518");
            DropIndex("dbo.PublicPhoneItem2", new[] { "data_54518_ID" });
            DropTable("dbo.PublicPhoneItem2");
        }
    }
}
