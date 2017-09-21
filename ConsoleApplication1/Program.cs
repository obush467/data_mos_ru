using System.Text;
//using Newtonsoft.Json;
using System.IO;
using System.Data.Entity;
using System.Net;
using System;
using System.Collections.Generic;
using data_mos_ru;

namespace ConsoleApplication1

{
    class Program
    {

        static void Main(string[] args)



        {


            data_mos_ru.data_mos_ru_Operator dmrOper;
            dmrOper = new data_mos_ru.data_mos_ru_Operator("GBUMATC");
          
            //dmrOper.DeserializeUM("e:\\data-6427-2016-12-06.json");
            //dmrOper.DeserializeUM_type("E:\\data.mos.ru\\data-6430-2016-10-12.json");

            //dmrOper.DeserializeTM("e:\\data.mos.ru\\Общемосковский классификатор территорий в Москве (ОМК 005-2013) Раздел 1.json");
            //dmrOper.DeserializeTMED("e:\\data.mos.ru\\Общемосковский классификатор территорий в Москве (ОМК 005-2013) Раздел 2.json");
            //dmrOper.DeserializeTM_Type("e:\\data.mos.ru\\Общемосковский классификатор территорий в Москве (ОМК 005-2013) Раздел 3.json");

            //dmrOper.DeserializeMO("E:\\data.mos.ru\\data-6435-2016-12-13.json");
            //dmrOper.DeserializeMO_Type("E:\\data.mos.ru\\Общемосковский классификатор муниципальных образований Москвы (ОМК 003-2013) Раздел 2.json");

            //dmrOper.DeserializeOMK002_2013_1("E:\\data.mos.ru\\Общемосковский классификатор территориальных единиц Москвы (ОМК 002-2013) Раздел 1.json");
            //dmrOper.DeserializeOMK002_2013_2("E:\\data.mos.ru\\Общемосковский классификатор территориальных единиц Москвы (ОМК 002-2013) Раздел 2.json");
            
            //dmrOper.DeserializeAO(Encoding.UTF8);
            //dmrOper.DeserializeAO("E:\\data.mos.ru\\data-4277-2016-12-21-1.json");
            //dmrOper.DeserializeAO("E:\\data.mos.ru\\data-4277-2016-12-21-2.json");
            //dmrOper.DeserializeAO("E:\\data.mos.ru\\data-4277-2016-12-21-3.json");
            //dmrOper.DeserializeAO("E:\\data.mos.ru\\data-4277-2016-12-21-4.json");

            dmrOper.LoadGeoJSON_AO(File.OpenRead("E:\\Filetable1\\ao.geojson"), Encoding.UTF8);

            //dmrOper.LoadGeoJSON_MO(File.OpenRead("E:\\Filetable1\\mo.geojson"), Encoding.UTF8);
            
        }
    }
}
