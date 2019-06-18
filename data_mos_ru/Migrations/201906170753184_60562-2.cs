namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _605622 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("data_mos_ru.AO_60562");
           // AlterColumn("data_mos_ru.AO_60562", "ID", c => c.Guid(nullable: false, identity: true));
           // AddPrimaryKey("data_mos_ru.AO_60562", "ID");
           // DropColumn("data_mos_ru.AO_60562", "ID1");
        }
        
        public override void Down()
        {
            //AddColumn("data_mos_ru.AO_60562", "ID1", c => c.Guid(nullable: false, identity: true));
            //DropPrimaryKey("data_mos_ru.AO_60562");
            //AlterColumn("data_mos_ru.AO_60562", "ID", c => c.Int(nullable: false));
            //AddPrimaryKey("data_mos_ru.AO_60562", "ID");
        }
    }
}
