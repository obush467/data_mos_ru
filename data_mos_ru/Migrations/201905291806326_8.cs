namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("data_mos_ru.AO_60562", "D_FIAS", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("data_mos_ru.AO_60562", "D_FIAS", c => c.String());
        }
    }
}
