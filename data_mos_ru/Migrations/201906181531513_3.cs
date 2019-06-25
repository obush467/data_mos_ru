namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("data_mos_ru.EmailItem", "Data_1181_7382_Id", "dbo.Data_1181_7382");
            DropIndex("data_mos_ru.EmailItem", new[] { "Data_1181_7382_Id" });
            DropColumn("data_mos_ru.EmailItem", "Data_1181_7382_Id");
        }

        public override void Down()
        {
            AddColumn("data_mos_ru.EmailItem", "Data_1181_7382_Id", c => c.Guid());
            CreateIndex("data_mos_ru.EmailItem", "Data_1181_7382_Id");
            AddForeignKey("data_mos_ru.EmailItem", "Data_1181_7382_Id", "dbo.Data_1181_7382", "Id");
        }
    }
}
