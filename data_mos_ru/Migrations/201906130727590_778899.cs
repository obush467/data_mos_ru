namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _778899 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UPRs",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Value = c.String(),
                        Label = c.String(),
                        Url = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UPRs");
        }
    }
}
