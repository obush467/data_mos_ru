namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data_1181_7382_ChiefPhoneItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Data_1181_7382_OrgInfoItem_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data_1181_7382_OrgInfoItem", t => t.Data_1181_7382_OrgInfoItem_Id)
                .Index(t => t.Data_1181_7382_OrgInfoItem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Data_1181_7382_ChiefPhoneItem", "Data_1181_7382_OrgInfoItem_Id", "dbo.Data_1181_7382_OrgInfoItem");
            DropIndex("dbo.Data_1181_7382_ChiefPhoneItem", new[] { "Data_1181_7382_OrgInfoItem_Id" });
            DropTable("dbo.Data_1181_7382_ChiefPhoneItem");
        }
    }
}
