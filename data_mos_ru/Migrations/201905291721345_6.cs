namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("data_mos_ru.AO_60562", "DREG", c => c.String());
            AlterColumn("data_mos_ru.AO_60562", "D_FIAS", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("data_mos_ru.AO_60562", "D_FIAS", c => c.DateTime());
            AlterColumn("data_mos_ru.AO_60562", "DREG", c => c.DateTime());
        }
    }
}
