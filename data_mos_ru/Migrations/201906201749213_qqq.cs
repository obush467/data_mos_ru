namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class qqq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists");
            DropIndex("dom_mos_ru.Houses", new[] { "HouseList_ID" });
            AlterColumn("dom_mos_ru.Houses", "HouseList_ID", c => c.Guid(nullable: false));
            CreateIndex("dom_mos_ru.Houses", "HouseList_ID");
            AddForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists", "ID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists");
            DropIndex("dom_mos_ru.Houses", new[] { "HouseList_ID" });
            AlterColumn("dom_mos_ru.Houses", "HouseList_ID", c => c.Guid());
            CreateIndex("dom_mos_ru.Houses", "HouseList_ID");
            AddForeignKey("dom_mos_ru.Houses", "HouseList_ID", "dom_mos_ru.HouseLists", "ID");
        }
    }
}
