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
                cfg.AddProfile(new Organization_v1_1_Organization_MapProfile(ContexUNS));
                cfg.AddProfile(new Organization_v1List_Organization_MapProfile(ContexUNS));
                cfg.AddProfile<Data_2624_8684_Organization_MapProfile>();
                cfg.AddProfile<Data_Organization_2834_Organization_MapProfile>();
                cfg.AddProfile<Data_Organization_4149_MapProfile>();
                cfg.AddProfile<Data_7611_Organization_MapProfile>();
                cfg.AddProfile(new Data_7612_Organization_MapProfile());
                cfg.AddProfile(new Data_Organization_5988_MapProfile(ContexUNS));
                cfg.AddProfile<Data_Organization_28509_Organization_MapProfile>();
                cfg.AddProfile<Data_Organization_8672_Organization_MapProfile>();
                cfg.AddProfile<Data_Organization_7949_Organization_MapProfile>();
                cfg.AddProfile(new Data_Organization_9773_OwnerRawAddress_MapProfile(ContexUNS));


                cfg.AddProfile(new Fias_MapProfile());
            });
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}