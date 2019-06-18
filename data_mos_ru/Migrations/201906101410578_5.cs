namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstitutionsAddressesItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ChiefName = c.String(),
                        ChiefPosition = c.String(),
                        FullName = c.String(),
                        District = c.String(),
                        Address = c.String(),
                        WebSite = c.String(),
                        AdmArea = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
            CreateTable(
                "dbo.AvailabilityItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        available_o = c.String(),
                        available_z = c.String(),
                        available_s = c.String(),
                        available_k = c.String(),
                        InstitutionsAddressesItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstitutionsAddressesItems", t => t.InstitutionsAddressesItem_ID)
                .Index(t => t.InstitutionsAddressesItem_ID);
            
            CreateTable(
                "dbo.Available_elementItem",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        available_index = c.String(),
                        Area_mgn = c.String(),
                        Element_mgn = c.String(),
                        available_degree = c.String(),
                        Group_mgn = c.String(),
                        AvailabilityItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AvailabilityItems", t => t.AvailabilityItem_ID)
                .Index(t => t.AvailabilityItem_ID);
            
            CreateTable(
                "dbo.PublicPhoneItem1",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(),
                        InstitutionsAddressesItem_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstitutionsAddressesItems", t => t.InstitutionsAddressesItem_ID)
                .Index(t => t.InstitutionsAddressesItem_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstitutionsAddressesItems", "data_54518_ID", "dbo.data_54518");
            DropForeignKey("dbo.PublicPhoneItem1", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems");
            DropForeignKey("dbo.AvailabilityItems", "InstitutionsAddressesItem_ID", "dbo.InstitutionsAddressesItems");
            DropForeignKey("dbo.Available_elementItem", "AvailabilityItem_ID", "dbo.AvailabilityItems");
            DropIndex("dbo.PublicPhoneItem1", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("dbo.Available_elementItem", new[] { "AvailabilityItem_ID" });
            DropIndex("dbo.AvailabilityItems", new[] { "InstitutionsAddressesItem_ID" });
            DropIndex("dbo.InstitutionsAddressesItems", new[] { "data_54518_ID" });
            DropTable("dbo.PublicPhoneItem1");
            DropTable("dbo.Available_elementItem");
            DropTable("dbo.AvailabilityItems");
            DropTable("dbo.InstitutionsAddressesItems");
        }
    }
}
