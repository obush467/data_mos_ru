namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Data_577_5609_AvailabilityItem", "Data_577_5609_ObjectAddressItem_Id", "dbo.Data_577_5609_ObjectAddressItem");
            DropIndex("dbo.Data_577_5609_AvailabilityItem", new[] { "Data_577_5609_ObjectAddressItem_Id" });
            DropTable("dbo.Data_577_5609_AvailabilityItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Data_577_5609_AvailabilityItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        available_z = c.String(),
                        available_o = c.String(),
                        available_s = c.String(),
                        available_k = c.String(),
                        Data_577_5609_ObjectAddressItem_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Data_577_5609_AvailabilityItem", "Data_577_5609_ObjectAddressItem_Id");
            AddForeignKey("dbo.Data_577_5609_AvailabilityItem", "Data_577_5609_ObjectAddressItem_Id", "dbo.Data_577_5609_ObjectAddressItem", "Id");
        }
    }
}
