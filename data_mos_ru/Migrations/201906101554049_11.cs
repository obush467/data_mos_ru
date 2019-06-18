namespace data_mos_ru.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("data_mos_ru.EmailItem", "Email", c => c.String(maxLength: 50));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "ChiefName", c => c.String(maxLength: 150));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "ChiefPosition", c => c.String(maxLength: 100));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "FullName", c => c.String(maxLength: 1000));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "District", c => c.String(maxLength: 100));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "Address", c => c.String(maxLength: 1000));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "WebSite", c => c.String(maxLength: 100));
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "AdmArea", c => c.String(maxLength: 100));
            AlterColumn("data_mos_ru.PublicPhoneItem1", "PublicPhone", c => c.String(maxLength: 30));
            AlterColumn("data_mos_ru.PublicPhoneItem2", "PublicPhone", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("data_mos_ru.PublicPhoneItem2", "PublicPhone", c => c.String());
            AlterColumn("data_mos_ru.PublicPhoneItem1", "PublicPhone", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "AdmArea", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "WebSite", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "Address", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "District", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "FullName", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "ChiefPosition", c => c.String());
            AlterColumn("data_mos_ru.InstitutionsAddressesItem", "ChiefName", c => c.String());
            AlterColumn("data_mos_ru.EmailItem", "Email", c => c.String());
        }
    }
}
