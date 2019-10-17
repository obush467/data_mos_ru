using data_mos_ru.Converters;
using data_mos_ru.Entities;
using data_mos_ru.Loaders;
using data_mos_ru.Operators;
using System;
using System.IO;
using System.Text;

namespace ConsoleApplication1

{
    class Program
    {
        private static void Main(string[] args)
        {



            UriBuilder uriBuilder = new UriBuilder("http://dom.mos.ru/Building/Details?pk=0d107a57-5fbd-4763-8196-2488c92f0a20");
            Data_mos_ru_Operator dmrOper = new Data_mos_ru_Operator("integra");
            dom_mos_ru_Operator domOper = new dom_mos_ru_Operator("integra");
            Rospt_ru_Operator rptOper = new Rospt_ru_Operator();
            // rptOper.AppendAddresses();
            var ttt = new DaDataLoader();
            ttt.Load();
            dmrOper.Room();
            DirectoryInfo wdir = new DirectoryInfo("C:\\Users\\Bushmakin\\Documents\\Новая папка\\data_mos_ru");
            FileInfo[] d6427 = wdir.GetFiles("data-6427*.json");
            FileInfo[] d6430 = wdir.GetFiles("data-6430*.json");
            FileInfo[] d6431 = wdir.GetFiles("data-6431*.json");
            FileInfo[] d6433 = wdir.GetFiles("data-6433*.json");
            FileInfo[] d6435 = wdir.GetFiles("data-6435*.json");
            FileInfo[] d6438 = wdir.GetFiles("data-6438*.json");
            FileInfo[] d6436 = wdir.GetFiles("data-6436*.json");
            FileInfo[] d6432 = wdir.GetFiles("data-6432*.json");
            FileInfo[] d29580 = wdir.GetFiles("data-29580*.json");
            FileInfo[] d2624_8684 = wdir.GetFiles("data-8684*.json");//Религиозные объекты Русской православной церкви
            FileInfo[] d7612 = wdir.GetFiles("data-7612*.json");//Синагоги
            FileInfo[] d7609 = wdir.GetFiles("data-7609*.json");//Католические храмы
            FileInfo[] d7610 = wdir.GetFiles("data-7610*.json");//Мечети
            FileInfo[] d7611 = wdir.GetFiles("data-7611*.json");//Монастыри
            FileInfo[] d1641_5988 = wdir.GetFiles("data-5988*.json");
            FileInfo[] d54518 = wdir.GetFiles("data-54518*.json");
            FileInfo[] d7382 = wdir.GetFiles("data-7382*.json");
            FileInfo[] dUPR = wdir.GetFiles("UPR.json");
            FileInfo[] d5883 = wdir.GetFiles("data-5883*.json"); //Образовательные учреждения Департамента здравоохранения ???
            FileInfo[] d5609 = wdir.GetFiles("data-5609*.json"); //Больницы взрослые
            FileInfo[] d5623 = wdir.GetFiles("data-5623*.json"); //Больницы детские и специализированные
            FileInfo[] d5636 = wdir.GetFiles("data-5636*.json"); //Госпитали для ветеранов
            FileInfo[] d5662 = wdir.GetFiles("data-5662*.json"); //Диспансеры
            FileInfo[] d5675 = wdir.GetFiles("data-5675*.json"); //Дневные стационары
            FileInfo[] d5714 = wdir.GetFiles("data-5714*.json"); //Женские консультации
            FileInfo[] d5753 = wdir.GetFiles("data-5753*.json"); //Кабинеты анонимного обследования на ВИЧ (СПИД)
            FileInfo[] d8061 = wdir.GetFiles("data-8061*.json"); //Кабинеты иммунопрофилактики
            FileInfo[] d5766 = wdir.GetFiles("data-5766*.json"); //Молочные кухни
            FileInfo[] d5727 = wdir.GetFiles("data-5727*.json"); //Онкологические центры
            FileInfo[] d29487 = wdir.GetFiles("data-29487*.json"); //Паллиативная медицинская помощь в стационарных условиях
            FileInfo[] d5779 = wdir.GetFiles("data-5779*.json"); //Поликлиническая помощь взрослым
            FileInfo[] d5792 = wdir.GetFiles("data-5792*.json"); //Поликлиническая помощь детям
            FileInfo[] d5818 = wdir.GetFiles("data-5818*.json"); //Родильные дома
            FileInfo[] d5831 = wdir.GetFiles("data-5831*.json"); //Санатории
            FileInfo[] d5844 = wdir.GetFiles("data-5844*.json"); //
            FileInfo[] d5870 = wdir.GetFiles("data-5870*.json"); //Специализированные медицинские учреждения
            FileInfo[] d5688 = wdir.GetFiles("data-5688*.json"); //Станции переливания крови
            FileInfo[] d5909 = wdir.GetFiles("data-5909*.json"); //Стоматологические поликлиники взрослые
            FileInfo[] d5948 = wdir.GetFiles("data-5948*.json"); //Стоматологические поликлиники детские
            FileInfo[] d5313 = wdir.GetFiles("data-5313*.json"); //Танатологические отделения (морги)
            FileInfo[] d5961 = wdir.GetFiles("data-5961*.json"); //Травматологические пункты
            FileInfo[] d5935 = wdir.GetFiles("data-5935*.json"); //Хосписы
            FileInfo[] d5701 = wdir.GetFiles("data-5701*.json"); //Центры вакцинации
            FileInfo[] d5922 = wdir.GetFiles("data-5922*.json"); //Центры здоровья
            FileInfo[] d5649 = wdir.GetFiles("data-5649*.json"); //Центры профилактики и борьбы с ВИЧ (СПИД)
            FileInfo[] d5896 = wdir.GetFiles("data-5896*.json"); //Центры спортивной медицины и реабилитации
            FileInfo[] d7432 = wdir.GetFiles("data-7432*.json"); //Театры
            FileInfo[] d7361 = wdir.GetFiles("data-7361*.json"); //Театры
            FileInfo[] d8303 = wdir.GetFiles("data-8303*.json"); //Спортивные объекты города Москвы
            FileInfo[] d6434 = wdir.GetFiles("data-6434*.json"); //
            FileInfo[] d2762 = wdir.GetFiles("data-2762*.json"); //Государственные казенные учреждения «Инженерные службы» районов города Москвы
            FileInfo[] d2758 = wdir.GetFiles("data-2758*.json"); //Государственные казённые учреждения дирекции жилищно-коммунального хозяйства и благоустройства административных округов города Москвы и их филиалы
            FileInfo[] d2835 = wdir.GetFiles("data-2835*.json"); //Ветеринарные учреждения
            FileInfo[] d7273 = wdir.GetFiles("data-7273*.json"); //
            FileInfo[] d7442 = wdir.GetFiles("data-7442*.json"); //Учреждения, осуществляющие управленческие функции
            FileInfo[] d26099 = wdir.GetFiles("data-26099*.json");//Центры занятости населения
            FileInfo[] d26169 = wdir.GetFiles("data-26169*.json");//Специализированные центры труда и занятости населения
            FileInfo[] d28509 = wdir.GetFiles("data-28509*.json");//Стационарные торговые объекты
            FileInfo[] d2748 = wdir.GetFiles("data-2748*.json");// //2748 Стационарные общественные туалеты https://op.mos.ru/EHDWSREST/catalog/export/get?id=550209
            FileInfo[] d8672 = wdir.GetFiles("data-8672*.json"); //8672 Данные по промышленным предприятиям https://op.mos.ru/EHDWSREST/catalog/export/get?id=430801
            //1692 Объекты ритуального обслуживания https://op.mos.ru/EHDWSREST/catalog/export/get?id=544401
            //7051 Организации для детей-сирот и детей, оставшихся без попечения родителей https://op.mos.ru/EHDWSREST/catalog/export/get?id=552349
            //7067 Пансионаты для ветеранов  https://op.mos.ru/EHDWSREST/catalog/export/get?id=551705
            //7188 Психоневрологические интернаты https://op.mos.ru/EHDWSREST/catalog/export/get?id=552365
            //7257 Территориальные центры социального обслуживания https://op.mos.ru/EHDWSREST/catalog/export/get?id=553785
            FileInfo[] d7949 = wdir.GetFiles("data-7949*.json");  //7949   Гостиницы https://op.mos.ru/EHDWSREST/catalog/export/get?id=549941
            //8261 Перечень спортивных учреждений Москвы https://op.mos.ru/EHDWSREST/catalog/export/get?id=537797
            FileInfo[] d9773 = wdir.GetFiles("data-9773*.json"); //Объекты культурного наследия
            FileInfo[] d4149 = wdir.GetFiles("data-4149*.json");//Штабы городских народных дружин
            FileInfo[] d2834 = wdir.GetFiles("data-2834*.json");//Розничные рынки
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d7432[0].FullName, Encoding.GetEncoding(1251))); //не пошло
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5896[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5649[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5922[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5701[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5935[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5961[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5313[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5909[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5948[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5688[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5870[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5844[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5831[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5818[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5792[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5779[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d29487[0].FullName, Encoding.GetEncoding(1251))); //не прошла, менять формат
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5727[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5766[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d8061[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5753[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5714[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5675[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5662[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5636[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5623[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5609[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_577_5609>(d5883[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<AO_60562>(d29580[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_7611>(d7611[0].FullName,Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_7361>(d7361[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_7612>(d7610[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_7612>(d7609[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_7612>(d7612[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_2624_8684>(d2624_8684[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1>(d8303[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_Organization_8672>(d8672[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_Organization_7949>(d7949[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update<Data_Organization_9773>(dmrOper.Loader. Deserialize<Data_Organization_9773>(d9773[0], Encoding.GetEncoding(1251)), new Data_Organization_9773_Converter(dmrOper.ContexUNS));
            //dmrOper.Update<Data_Organization_9773>(dmrOper.Loader.Convert<Data_Organization_9773>(d9773[0].FullName, Encoding.GetEncoding(1251)),new Data_Organization_9773_Converter(dmrOper.ContexUNS));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_Organization_4149>(d4149[0].FullName, Encoding.GetEncoding(1251)));
            dmrOper.Update(dmrOper.Loader.Convert<Data_Organization_2834>(d2834[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_Organization_5988>(d1641_5988[0].FullName, Encoding.GetEncoding(1251))); /*Реестр учреждений города Москвы*/
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1_1>(d26099[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1_1>(d26169[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<Data_Organization_2748>(d2748[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_28509>(d28509[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Convert<data_54518>(d54518[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1_Base>(d7382[0].FullName,Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v2>(d2762[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v2>(d2758[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v3>(d2835[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1>(d7273[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1>(d7442[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v2>(d2762[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v2>(d2758[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v3>(d2835[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1>(d7273[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Loader.Convert<data_Organization_v1>(d7442[0].FullName, Encoding.GetEncoding(1251)));
            //dmrOper.Update(dmrOper.Convert<UPR>(dUPR[0].FullName, Encoding.UTF8));
            //domOper.UpdateHouses();
            //domOper.LoadDom();
            //dmrOper.LoadUPRsFromBuildings();         
            // Task.WaitAll(new Task[]
            //{
            //    Task.Run(() => domOper.LoadUPRsBlockingCollection())//,
            //Task.Run(() => dmrOper.LoadBuildingsBlockingCollection())
            // });

            //dmrOper.UpdateOrganizationsByDomMosRu();
            //dmrOper.Update(dmrOper.Loader.Convert<OMK002_2013_1>(d6434[0].FullName,Encoding.GetEncoding(1251)));

            //dmrOper.DeserializeOMK002_2013_2(d6436[0].FullName, Encoding.GetEncoding(1251));


            //dmrOper.DeserializeAO(new DirectoryInfo("D:\\data_mos_ru\\data-4277-2017-11-23").GetFiles("*.json"), Encoding.GetEncoding(1251));
            //dmrOper.DeserializeAO(new FileInfo("D:\\data.mos.ru\\data-4277-2016-12-21-2.json"), Encoding.UTF8);
            //dmrOper.DeserializeAO(new FileInfo("D:\\data.mos.ru\\data-4277-2016-12-21-3.json"), Encoding.UTF8);
            //dmrOper.DeserializeAO(new FileInfo("D:\\data.mos.ru\\data-4277-2016-12-21-4.json"), Encoding.UTF8);

            //dmrOper.DeserializeTMED(d6432[0].FullName, Encoding.GetEncoding(1251));

            //dmrOper.DeserializeAO(Encoding.UTF8);
            //dmrOper.LoadGeoJSON_AO(File.OpenRead("D:\\Filetable1\\ao.geojson"), Encoding.UTF8);

            //dmrOper.LoadGeoJSON_MO(File.OpenRead("D:\\Filetable1\\mo.geojson"), Encoding.UTF8);

            //dmrOper.DeserializeTM_Type(d6433[0].FullName, Encoding.GetEncoding(1251));
            //dmrOper.DeserializeTM(d6431[0].FullName, Encoding.GetEncoding(1251));

            //dmrOper.DeserializeMO_Type(d6438[0].FullName, Encoding.GetEncoding(1251));
            //dmrOper.DeserializeMO(d6435[0].FullName,Encoding.GetEncoding(1251));
            //dmrOper.ReplacePost();

        }
    }
}
