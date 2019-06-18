namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PublicPhoneItem1", new[] { "data_54518_ID" });
            CreateTable(
                "dbo.PublicPhoneItem2",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.data_54518_ID);
            
            DropColumn("dbo.PublicPhoneItem1", "data_54518_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PublicPhoneItem1", "data_54518_ID", c => c.Guid());
            DropIndex("dbo.PublicPhoneItem2", new[] { "data_54518_ID" });
            DropTable("dbo.PublicPhoneItem2");
            CreateIndex("dbo.PublicPhoneItem1", "data_54518_ID");
        }
    }
}
