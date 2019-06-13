namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LicensingAndAccreditationItems",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        LicenseSeries = c.String(),
                        LicenseNumber = c.String(),
                        LicenseExpires = c.String(),
                        AccreditationAvailability = c.String(),
                        LicenseAvailability = c.String(),
                        data_54518_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_54518", t => t.data_54518_ID)
                .Index(t => t.data_54518_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LicensingAndAccreditationItems", "data_54518_ID", "dbo.data_54518");
            DropIndex("dbo.LicensingAndAccreditationItems", new[] { "data_54518_ID" });
            DropTable("dbo.LicensingAndAccreditationItems");
        }
    }
}
