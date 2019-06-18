namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class dom_mos_ru_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dom_mos_ru.UPRsites",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Uri = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dom_mos_ru.HouseLists",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        UPRsite_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.UPRsites", t => t.UPRsite_ID)
                .Index(t => t.UPRsite_ID);
            
            CreateTable(
                "dom_mos_ru.Houses",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        HouseList_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.HouseLists", t => t.HouseList_ID)
                .Index(t => t.HouseList_ID);
            
            CreateTable(
                "dom_mos_ru.InfTableRows",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        UPRsite_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dom_mos_ru.UPRsites", t => t.UPRsite_ID)
                .Index(t => t.UPRsite_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists");
            DropIndex("dom_mos_ru.InfTableRows", new[] { "UPRsite_ID" });
            DropIndex("dom_mos_ru.Houses", new[] { "HouseList_ID" });
            DropIndex("dom_mos_ru.HouseLists", new[] { "UPRsite_ID" });
            DropTable("dom_mos_ru.InfTableRows");
            DropTable("dom_mos_ru.Houses");
            DropTable("dom_mos_ru.HouseLists");
            DropTable("dom_mos_ru.UPRsites");
        }
    }
}
