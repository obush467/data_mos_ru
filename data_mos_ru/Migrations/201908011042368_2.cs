namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data_577_5609_PublicPhoneItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        Data_577_5609_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_577_5609", t => t.Data_577_5609_Id)
                .Index(t => t.Data_577_5609_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Data_577_5609_PublicPhoneItem", "Data_577_5609_Id", "dbo.Data_577_5609");
            DropIndex("dbo.Data_577_5609_PublicPhoneItem", new[] { "Data_577_5609_Id" });
            DropTable("dbo.Data_577_5609_PublicPhoneItem");
        }
    }
}
