using AutoMapper;
using data_mos_ru.Mappers;

namespace data_mos_ru.Operators
{

    public partial class Data_mos_ru_Operator
    {
        public IMapper Mapper;
        protected virtual MapperConfiguration mapperConfiguration { get; private set; }
        public void mapConfigure()
        {
            mapperConfiguration =
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Organization_Organization_MapProfile>();
                cfg.AddProfile<Organization_v2_Organization_MapProfile>();
                cfg.AddProfile<Organization_v3_Organization_MapProfile>();
                cfg.AddProfile(new Organization_v1_Organization_MapProfile(ContexUNS));
                cfg.AddProfile(new Organization_v1List_Organization_MapProfile(ContexUNS));
                cfg.AddProfile<Data_2624_8684_Organization_MapProfile>();
                cfg.AddProfile<Data_7611_Organization_MapProfile>();
                cfg.AddProfile(new Data_7612_Organization_MapProfile());
                cfg.AddProfile(new Data_Organization_5988_MapProfile(ContexUNS));

            });
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}