namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dom_mos_ru_7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dom_mos_ru.Houses", "Address", c => c.String());
            AddColumn("dom_mos_ru.Houses", "AdmArea", c => c.String());
            AddColumn("dom_mos_ru.Houses", "YearOfConstruction", c => c.Int());
            AddColumn("dom_mos_ru.Houses", "Series", c => c.String());
            AddColumn("dom_mos_ru.Houses", "StoreysCount", c => c.Int());
            AddColumn("dom_mos_ru.Houses", "TotalArea", c => c.String());
            AddColumn("dom_mos_ru.Houses", "TotalAreaResidentialPremises", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dom_mos_ru.Houses", "TotalAreaResidentialPremises");
            DropColumn("dom_mos_ru.Houses", "TotalArea");
            DropColumn("dom_mos_ru.Houses", "StoreysCount");
            DropColumn("dom_mos_ru.Houses", "Series");
            DropColumn("dom_mos_ru.Houses", "YearOfConstruction");
            DropColumn("dom_mos_ru.Houses", "AdmArea");
            DropColumn("dom_mos_ru.Houses", "Address");
        }
    }
}
