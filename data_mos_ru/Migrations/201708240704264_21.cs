namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("data_mos_ru.AO", "AdmArea", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.AO", "system_object_id", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "MO_Code", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "MO_Name", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "MO_Trans", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "MO_Type", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "MO_TE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "MO_OKTMO", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.MO", "geoData", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.OMK002_2013_2", "Cells_Kod", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.OMK002_2013_2", "Cells_Name", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Number", c => c.Int());
            AlterColumn("data_mos_ru.TMED", "Cells_global_id", c => c.Int());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_COMM", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Cells_TM_NAMES", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Cells_TM_TRANS", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Cells_TM_TYPE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Cells_TM_TE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Cells_TM_KLADR", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TMED", "Cells_TM_NAMEF", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_CODE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_NAMEF", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_NAMES", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_TRANS", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_TYPE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_TE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_KLADR", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.TM", "Cells_TM_STAT", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM_Type", "system_object_id", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM_Type", "UM_STAT", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM_Type", "UM_TYPEC", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM_Type", "UM_TYPEN", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_CODE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "system_object_id", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_NAMEF", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_NAMES", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_TRANS", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_TYPE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_TM", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_TE", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "UM_KLADR", c => c.String(maxLength: 4000));
            AlterColumn("data_mos_ru.UM", "geoData", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("data_mos_ru.UM", "geoData", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_KLADR", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_TE", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_TM", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_TYPE", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_TRANS", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_NAMES", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_NAMEF", c => c.String());
            AlterColumn("data_mos_ru.UM", "system_object_id", c => c.String());
            AlterColumn("data_mos_ru.UM", "UM_CODE", c => c.String());
            AlterColumn("data_mos_ru.UM_Type", "UM_TYPEN", c => c.String());
            AlterColumn("data_mos_ru.UM_Type", "UM_TYPEC", c => c.String());
            AlterColumn("data_mos_ru.UM_Type", "UM_STAT", c => c.String());
            AlterColumn("data_mos_ru.UM_Type", "system_object_id", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_STAT", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_KLADR", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_TE", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_TYPE", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_TRANS", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_NAMES", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_NAMEF", c => c.String());
            AlterColumn("data_mos_ru.TM", "Cells_TM_CODE", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_NAMEF", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_KLADR", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_TE", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_TYPE", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_TRANS", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_NAMES", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_TM_COMM", c => c.String());
            AlterColumn("data_mos_ru.TMED", "Cells_global_id", c => c.Int(nullable: false));
            AlterColumn("data_mos_ru.TMED", "Number", c => c.Int(nullable: false));
            AlterColumn("data_mos_ru.OMK002_2013_2", "Cells_Name", c => c.String());
            AlterColumn("data_mos_ru.OMK002_2013_2", "Cells_Kod", c => c.String());
            AlterColumn("data_mos_ru.MO", "geoData", c => c.String());
            AlterColumn("data_mos_ru.MO", "MO_OKTMO", c => c.String());
            AlterColumn("data_mos_ru.MO", "MO_TE", c => c.String());
            AlterColumn("data_mos_ru.MO", "MO_Type", c => c.String());
            AlterColumn("data_mos_ru.MO", "MO_Trans", c => c.String());
            AlterColumn("data_mos_ru.MO", "MO_Name", c => c.String());
            AlterColumn("data_mos_ru.MO", "MO_Code", c => c.String());
            AlterColumn("data_mos_ru.AO", "system_object_id", c => c.String());
            AlterColumn("data_mos_ru.AO", "AdmArea", c => c.String());
        }
    }
}
