namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("data_mos_ru.AO_60562", "Adm_Area", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "VID", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "ADDRESS", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P1", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P2", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P3", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P4", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P5", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P6", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P7", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P90", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "P91", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L1_TYPE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L1_VALUE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L2_TYPE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L2_VALUE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L3_TYPE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L3_VALUE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L4_TYPE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L4_VALUE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L5_TYPE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "L5_VALUE", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "DISTRICT", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "N_FIAS", c => c.Guid());
            AddColumn("data_mos_ru.AO_60562", "D_FIAS", c => c.DateTime());
            AddColumn("data_mos_ru.AO_60562", "KLADR", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "ADR_TYPE", c => c.String(maxLength: 4000));
            DropColumn("data_mos_ru.AO_60562", "AdmArea");
            DropColumn("data_mos_ru.AO_60562", "system_object_id");
            DropColumn("data_mos_ru.AO_60562", "KAD_RN");
            DropColumn("data_mos_ru.AO_60562", "KAD_KV");
            DropColumn("data_mos_ru.AO_60562", "KAD_ZU");
            DropColumn("data_mos_ru.AO_60562", "DMT");
            DropColumn("data_mos_ru.AO_60562", "KRT");
            DropColumn("data_mos_ru.AO_60562", "VLD");
            DropColumn("data_mos_ru.AO_60562", "STRT");
            DropColumn("data_mos_ru.AO_60562", "SOOR");
            DropColumn("data_mos_ru.AO_60562", "VYVAD");
            DropColumn("data_mos_ru.AO_60562", "ADRES");
        }
        
        public override void Down()
        {
            AddColumn("data_mos_ru.AO_60562", "ADRES", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "VYVAD", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "SOOR", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "STRT", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "VLD", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "KRT", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "DMT", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "KAD_ZU", c => c.Int());
            AddColumn("data_mos_ru.AO_60562", "KAD_KV", c => c.Int());
            AddColumn("data_mos_ru.AO_60562", "KAD_RN", c => c.Int());
            AddColumn("data_mos_ru.AO_60562", "system_object_id", c => c.String(maxLength: 4000));
            AddColumn("data_mos_ru.AO_60562", "AdmArea", c => c.String(maxLength: 4000));
            DropColumn("data_mos_ru.AO_60562", "ADR_TYPE");
            DropColumn("data_mos_ru.AO_60562", "KLADR");
            DropColumn("data_mos_ru.AO_60562", "D_FIAS");
            DropColumn("data_mos_ru.AO_60562", "N_FIAS");
            DropColumn("data_mos_ru.AO_60562", "DISTRICT");
            DropColumn("data_mos_ru.AO_60562", "L5_VALUE");
            DropColumn("data_mos_ru.AO_60562", "L5_TYPE");
            DropColumn("data_mos_ru.AO_60562", "L4_VALUE");
            DropColumn("data_mos_ru.AO_60562", "L4_TYPE");
            DropColumn("data_mos_ru.AO_60562", "L3_VALUE");
            DropColumn("data_mos_ru.AO_60562", "L3_TYPE");
            DropColumn("data_mos_ru.AO_60562", "L2_VALUE");
            DropColumn("data_mos_ru.AO_60562", "L2_TYPE");
            DropColumn("data_mos_ru.AO_60562", "L1_VALUE");
            DropColumn("data_mos_ru.AO_60562", "L1_TYPE");
            DropColumn("data_mos_ru.AO_60562", "P91");
            DropColumn("data_mos_ru.AO_60562", "P90");
            DropColumn("data_mos_ru.AO_60562", "P7");
            DropColumn("data_mos_ru.AO_60562", "P6");
            DropColumn("data_mos_ru.AO_60562", "P5");
            DropColumn("data_mos_ru.AO_60562", "P4");
            DropColumn("data_mos_ru.AO_60562", "P3");
            DropColumn("data_mos_ru.AO_60562", "P2");
            DropColumn("data_mos_ru.AO_60562", "P1");
            DropColumn("data_mos_ru.AO_60562", "ADDRESS");
            DropColumn("data_mos_ru.AO_60562", "VID");
            DropColumn("data_mos_ru.AO_60562", "Adm_Area");
        }
    }
}
