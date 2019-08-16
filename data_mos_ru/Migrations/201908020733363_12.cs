namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data_7611",
                c => new
                    {
                        Data_7611_ID = c.Guid(nullable: false, identity: true),
                        ID = c.Int(),
                        global_id = c.Int(),
                        NameOfReligiousOrganization = c.String(maxLength: 1000),
                        AdmArea = c.String(maxLength: 1000),
                        District = c.String(maxLength: 1000),
                        Address = c.String(maxLength: 1000),
                        PublicPhone = c.String(),
                        WebSite = c.String(maxLength: 1000),
                        geoData_Type = c.String(maxLength: 30),
                        geoData_Coordinates = c.Geography(),
                        geoData_Сenter = c.Geography(),
                    })
                .PrimaryKey(t => t.Data_7611_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Data_7611");
        }
    }
}
