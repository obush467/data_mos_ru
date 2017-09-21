namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            DropColumn("data_mos_ru.MO_Type", "Cells_MO_Type_Fantastic");
        }
        
        public override void Down()
        {
            AddColumn("data_mos_ru.MO_Type", "Cells_MO_Type_Fantastic", c => c.String(maxLength: 4000));
        }
    }
}
