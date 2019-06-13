namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _55 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.data_2624_8684_1",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        global_id = c.Int(),
                        Name = c.String(maxLength: 1000),
                        AdmArea = c.String(maxLength: 1000),
                        District = c.String(maxLength: 1000),
                        Address = c.String(maxLength: 1000),
                        MetroStation = c.String(maxLength: 1000),
                        MetroLine = c.String(maxLength: 1000),
                        WebSite = c.String(maxLength: 1000),
                        geoData_Type = c.String(maxLength: 30),
                        geoData_Coordinates = c.Geography(),
                        geoData_Сenter = c.Geography(),
                        Longitude_WGS84 = c.Double(),
                        Latitude_WGS84 = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.publicPhones",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        PublicPhone = c.String(maxLength: 50),
                        ParentID_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.data_2624_8684_1", t => t.ParentID_ID)
                .Index(t => t.ParentID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.publicPhones", "ParentID_ID", "dbo.data_2624_8684_1");
            DropIndex("dbo.publicPhones", new[] { "ParentID_ID" });
            DropTable("dbo.publicPhones");
            DropTable("dbo.data_2624_8684_1");
        }
    }
}
