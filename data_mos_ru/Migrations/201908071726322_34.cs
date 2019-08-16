namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _34 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data_7361", "NumOfSeats", c => c.Single(nullable: false));
            DropColumn("dbo.Data_2624_8684", "ID");
            DropColumn("dbo.Data_7361_EmailItem", "Email");
            DropColumn("dbo.Data_7361_FaxItem", "Fax");
            DropColumn("dbo.Data_7361_ChiefPhoneItem", "ChiefPhone");
            DropColumn("dbo.Data_7361_PublicPhoneItem", "PublicPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Data_7361_PublicPhoneItem", "PublicPhone", c => c.String());
            AddColumn("dbo.Data_7361_ChiefPhoneItem", "ChiefPhone", c => c.String());
            AddColumn("dbo.Data_7361_FaxItem", "Fax", c => c.String());
            AddColumn("dbo.Data_7361_EmailItem", "Email", c => c.String());
            AddColumn("dbo.Data_2624_8684", "ID", c => c.Int());
            AlterColumn("dbo.Data_7361", "NumOfSeats", c => c.Int(nullable: false));
        }
    }
}
