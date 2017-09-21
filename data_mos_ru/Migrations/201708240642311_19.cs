namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("data_mos_ru.MO_Type", "Cells_MO_Type_Fantastic", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("data_mos_ru.MO_Type", "Cells_MO_Type_Fantastic");
        }
    }
}
