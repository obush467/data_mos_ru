using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;
using data_mos_ru.Entityes;

namespace data_mos_ru
{
    public class JSONContext:DbContext
    {
        public JSONContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {        }
        public JSONContext() :base ("integra")
        {}

        public DbSet<UM> UMs { get; set; }
        public DbSet<UM_Type> UM_Types { get; set; }
        public DbSet<MO> MOs { get; set; }
        public DbSet<OMK002_2013_1> OMK002_2013_1s { get; set; }
        public DbSet<OMK002_2013_2> OMK002_2013_2s { get; set; }
        public DbSet<TM> TMs { get; set; }
        public DbSet<TMED> TMEDs { get; set; }
        public DbSet<AO> AOs { get; set; }
        public DbSet<AO_60562> AO_60562s { get; set; }
        public DbSet<MO_Type> MO_Types { get; set; }
        public DbSet<TM_Type> TM_Types { get; set; }
        public DbSet<AO_geojson> AO_geojsons { get; set; }
        public DbSet<MO_geojson> MO_geojsons { get; set; }
        public DbSet<data_2624_8684_1> Data_2624_8684_1 { get; set; }
        public DbSet<Data_1641_5988> data_1641_5988s { get; set; }
        public DbSet<data_54518> data_54518s { get; set; }
        public DbSet<UPR> UPRs { get; set; }

    }
}
