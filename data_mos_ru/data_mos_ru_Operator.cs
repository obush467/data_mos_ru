using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using data_mos_ru.Entities;
using log4net;
using System.Data.Entity.Migrations;


namespace data_mos_ru
{
    public class Operator
    {
        public JSONContext JsContext { get; set; }
        public static ILog Logger;
        private data_mos_ru_Loader Loader;
        private dom_mos_ru_Loader domLoader;
        protected string ConnectionString;

        public Operator(string connectionString)
        {
            log4net.Config.XmlConfigurator.Configure();
            JsContext = new JSONContext(connectionString);
            Logger = LogManager.GetLogger(typeof(Operator));
            Loader = new data_mos_ru_Loader("", Logger);
            domLoader = new dom_mos_ru_Loader(Logger);
            ConnectionString = connectionString;
        }

        public void UpdateHouses()
        {
            domLoader.UpdateHouses(Encoding.UTF8);
        }

        public void LoadDom()
        {
            //var ttt =domLoader.LoadUPR(JS.UPRs.ToList(),Encoding.UTF8);
            domLoader.LoadUpr(JsContext.UPRs.ToList(), Encoding.UTF8);
        }

        public List<T> Deserialize<T>(string fileName, Encoding encoding)
        {
            Logger.Info(string.Join(" ", "Запущено преобразование", typeof(T).Name));
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.Converters.Add(new GeoDataConverter());
            jss.Culture = CultureInfo.CurrentCulture;
            Logger.Info(string.Join(" ", "Преобразовано", typeof(T).Name));
            return JsonConvert.DeserializeObject<T[]>((new StreamReader(fileName, encoding)).ReadToEnd(), jss)
                .ToList<T>();
        }

        public List<List<T>> Convert<T>(string fileName, Encoding encoding)
        {
            int counter = 0;
            int counterLength = 200;
            var result = Deserialize<T>(fileName, encoding).GroupBy(_ => counter++ / counterLength).Distinct()
                .Select(v => v.ToList()).ToList();
            return result;
        }

        public void Update(List<List<AO_60562>> input)
        {
            int counter = 0;
            foreach (List<AO_60562> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.Global_ID == null);
                    counter = counter + block.Count;
                    foreach (AO_60562 row in block)
                    {
                        if (row.GeoData == null)
                        {
                            row.GeoData = new GeoData();
                        }
                    }

                    context.AO_60562s.AddOrUpdate(block.ToArray());
                    Logger.Info(string.Join(" ", typeof(AO_60562).Name, "Сохранено", block.Count.ToString(), "всего",
                        counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<UPR>> input)
        {
            int counter = 0;
            foreach (List<UPR> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.global_id == null);
                    counter = counter + block.Count;
                    context.UPRs.AddRange(block.ToArray());
                    Logger.Info(string.Join(" ", typeof(data_54518).Name, "Сохранено", block.Count.ToString(), "всего",
                        counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<data_54518>> input)
        {
            int counter = 0;
            foreach (List<data_54518> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter = counter + block.Count;
                    foreach (data_54518 row in block)
                    {
                        if (row.geoData == null)
                        {
                            row.geoData = new GeoData();
                        }
                    }

                    context.data_54518s.AddRange(block.ToArray());
                    Logger.Info(string.Join(" ", typeof(data_54518).Name, "Сохранено", block.Count.ToString(), "всего",
                        counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<Data_1641_5988>> input)
        {
            int counter = 0;
            foreach (List<Data_1641_5988> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter = counter + block.Count;
                    foreach (Data_1641_5988 row in block)
                    {
                        // if (row.GeoData == null)
                        // { row.GeoData = new geoData(); }
                    }

                    context.data_1641_5988s.AddOrUpdate(block.ToArray());
                    Logger.Info(string.Join(" ", typeof(Data_1641_5988).Name, "Сохранено", block.Count.ToString(),
                        "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<data_2624_8684>> input)
        {
            int counter = 0;
            foreach (List<data_2624_8684> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.global_id == null);
                    foreach (data_2624_8684 row in block)
                    {
                        if (row.geoData == null)
                        {
                            row.geoData = new GeoData();
                        }
                    }

                    context.Data_2624_8684.AddOrUpdate(block.ToArray());
                    Logger.Info(string.Join(" ", typeof(data_2624_8684).Name, "Сохранено", block.Count.ToString(),
                        "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }
    }
}

