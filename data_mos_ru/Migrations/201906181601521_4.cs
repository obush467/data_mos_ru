namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiefPhoneItems", "OrgInfoItem_Id", "dbo.OrgInfoItems");
            DropIndex("dbo.ChiefPhoneItems", new[] { "OrgInfoItem_Id" });
            DropTable("dbo.ChiefPhoneItems");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ChiefPhoneItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    ChiefPhone = c.String(),
                    OrgInfoItem_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.ChiefPhoneItems", "OrgInfoItem_Id");
            AddForeignKey("dbo.ChiefPhoneItems", "OrgInfoItem_Id", "dbo.OrgInfoItems", "Id");
        }
    }
}
