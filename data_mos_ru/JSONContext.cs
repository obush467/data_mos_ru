using data_mos_ru.Entities;
using System.Data.Entity;

namespace data_mos_ru
{
    public class JSONContext : DbContext
    {
        public JSONContext(string nameOrConnectionString) : base(nameOrConnectionString)
        { }
        public JSONContext() : base("integra")
        { }

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
        public DbSet<Data_2624_8684> Data_2624_8684 { get; set; }
        public DbSet<Data_Organization_5988> Data_1641_5988s { get; set; }
        public DbSet<Data_54518> Data_54518s { get; set; }
        public DbSet<SearchAutoCompleteResult> UPRs { get; set; }
        public DbSet<UPRsite> UPRsites { get; set; }
        public DbSet<House> Houses { get; set; }
        public virtual DbSet<InfTableRow> InfTableRows { get; set; }
        //public virtual DbSet<Data_1181_7382> Data_1181_7382s { get; set; }

        public virtual DbSet<Data_577_5609> Data_577_5609s { get; set; }
        public virtual DbSet<Data_7612> Data_7612s { get; set; }
        public virtual DbSet<Data_7611> Data_7611s { get; set; }
        //public virtual DbSet<Data_7361> Data_7361s { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

