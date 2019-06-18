namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShortTypeName = c.String(maxLength: 100),
                        FullTypeName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonPositionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PositionType = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonPositionTypes");
            DropTable("dbo.OrganizationTypes");
        }
    }
}
