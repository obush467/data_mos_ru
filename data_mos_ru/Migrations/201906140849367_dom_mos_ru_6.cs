namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dom_mos_ru_6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropPrimaryKey("dom_mos_ru.UPRsites");
            AlterColumn("dom_mos_ru.UPRsites", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dom_mos_ru.UPRsites", "ID");
            AddForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites", "ID");
            AddForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites");
            DropPrimaryKey("dom_mos_ru.UPRsites");
            AlterColumn("dom_mos_ru.UPRsites", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dom_mos_ru.UPRsites", "ID");
            AddForeignKey("dom_mos_ru.InfTableRows", "UPRsite_ID", "dom_mos_ru.UPRsites", "ID");
            AddForeignKey("dom_mos_ru.HouseLists", "UPRsite_ID", "dom_mos_ru.UPRsites", "ID");
        }
    }
}
