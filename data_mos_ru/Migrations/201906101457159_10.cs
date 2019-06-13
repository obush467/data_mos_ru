namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmailItems", newName: "EmailItem");
            RenameTable(name: "dbo.InstitutionsAddressesItems", newName: "InstitutionsAddressesItem");
            RenameTable(name: "dbo.AvailabilityItems", newName: "AvailabilityItem");
            RenameTable(name: "dbo.LicensingAndAccreditationItems", newName: "LicensingAndAccreditationItem");
            MoveTable(name: "dbo.data_54518", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.EmailItem", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.InstitutionsAddressesItem", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.AvailabilityItem", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.Available_elementItem", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.PublicPhoneItem1", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.LicensingAndAccreditationItem", newSchema: "data_mos_ru");
            MoveTable(name: "dbo.PublicPhoneItem2", newSchema: "data_mos_ru");
        }
        
        public override void Down()
        {
            MoveTable(name: "data_mos_ru.PublicPhoneItem2", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.LicensingAndAccreditationItem", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.PublicPhoneItem1", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.Available_elementItem", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.AvailabilityItem", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.InstitutionsAddressesItem", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.EmailItem", newSchema: "dbo");
            MoveTable(name: "data_mos_ru.data_54518", newSchema: "dbo");
            RenameTable(name: "dbo.LicensingAndAccreditationItem", newName: "LicensingAndAccreditationItems");
            RenameTable(name: "dbo.AvailabilityItem", newName: "AvailabilityItems");
            RenameTable(name: "dbo.InstitutionsAddressesItem", newName: "InstitutionsAddressesItems");
            RenameTable(name: "dbo.EmailItem", newName: "EmailItems");
        }
    }
}
