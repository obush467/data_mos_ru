using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Collections;
using System.Data.Entity.Spatial;
using System.Spatial;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection;
using data_mos_ru.Entityes;
using log4net;
using System.Threading;
using NetTopologySuite.Features;
using NetTopologySuite.IO;
using NetTopologySuite.Geometries;



namespace data_mos_ru
{
    public class data_mos_ru_Operator
    {
        private static JSONContext JS;
        public static ILog Logger;
        private data_mos_ru_Loader Loader;
        public data_mos_ru_Operator(string ConnectionString)
        {
            log4net.Config.XmlConfigurator.Configure();
            JS = new JSONContext(ConnectionString);        
            Logger = LogManager.GetLogger(typeof(data_mos_ru_Operator));
            Loader = new data_mos_ru_Loader("", Logger);
        }
        public void DeserializeTMs(string FileName)
        {
            Logger.Info("Запущено преобразование TM");
            Logger.InfoFormat("Преобразование TM запущено - {0}", DateTime.Now);
            TM[] TerVar = JsonConvert.DeserializeObject<TM[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано TM");
            JS.TMs.Create<TM>();
            JS.TMs.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено TM");
        }

        public void DeserializeTM_Type(string FileName)
        {
            Logger.Info("Запущено преобразование TM");
            Logger.InfoFormat("Преобразование TM запущено - {0}", DateTime.Now);
            TM_Type[] TerVar = JsonConvert.DeserializeObject<TM_Type[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано TM_Type");
            JS.TM_Types.Create<TM_Type>();
            JS.TM_Types.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено TM_Type");
        }

        public void DeserializeMO(string FileName)
        {
            Logger.Info("Запущено преобразование MO");
            MO[] TerVar = JsonConvert.DeserializeObject<MO[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано MO");
            JS.MOs.Create<MO>();
            JS.MOs.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено MO");

        }

        public void DeserializeMO_Type(string FileName)
        {
            Logger.Info("Запущено преобразование MO_Type");
            MO_Type[] TerVar = JsonConvert.DeserializeObject<MO_Type[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано MO_Type");
            JS.MO_Types.Create<MO_Type>();
            JS.MO_Types.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено MO_Type");

        }

        public void DeserializeOMK002_2013_1(string FileName)
        {
            Logger.Info("Запущено преобразование OMK002_2013_1");
            OMK002_2013_1[] TerVar = JsonConvert.DeserializeObject<OMK002_2013_1[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано OMK002_2013_1");
            JS.OMK002_2013_1s.Create<OMK002_2013_1>();
            JS.OMK002_2013_1s.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено OMK002_2013_1");
        }
        public void DeserializeOMK002_2013_2(string FileName)
        {
            Logger.Info("Запущено преобразование OMK002_2013_2");
            OMK002_2013_2[] TerVar = JsonConvert.DeserializeObject<OMK002_2013_2[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано OMK002_2013_2");
            JS.OMK002_2013_2s.Create<OMK002_2013_2>();
            JS.OMK002_2013_2s.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено OMK002_2013_2");
        }
        public void DeserializeUM_type(string FileName)
        {
            Logger.Info("Запущено преобразование UM_type");
            UM_Type[] TerVar = JsonConvert.DeserializeObject<UM_Type[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано UM_type");
            JS.UM_Types.Create<UM_Type>();
            JS.UM_Types.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено UM_type");
        }
        public void DeserializeTMED(string FileName)
        {
            Logger.Info("Запущено преобразование TMED");
            TMED[] TerVar = JsonConvert.DeserializeObject<TMED[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано TMED");
            TMED_DB dcs111 = new TMED_DB();
            //DataContractSerializer dcs = new DataContractSerializer(typeof(TMED), "", null, null, 0, true, true,dcs111);
          
            JS.TMEDs.Create<TMED>();
            JS.TMEDs.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено TMED");
        }

        public void DeserializeTM(string FileName)
        {
            Logger.Info("Запущено преобразование TM");
            TM[] TerVar = JsonConvert.DeserializeObject<TM[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано TM");
            JS.TMs.Create<TM>();
            JS.TMs.AddRange(TerVar);
            JS.SaveChanges();
            Logger.Info("Сохранено TM");
        }

        public void DeserializeUM(string FileName)
        {
            Logger.Info("Запущено преобразование UM");
            UM[] data = JsonConvert.DeserializeObject<UM[]>((new StreamReader(FileName, Encoding.UTF8)).ReadToEnd());
            Logger.Info("Преобразовано UM");
            JS.UMs.Create<UM>();
            JS.UMs.AddRange(data);
            JS.SaveChanges();
            Logger.Info("Сохранено UM");
        }

        public void DeserializeAO(FileInfo FileName, Encoding encoding)
        { DeserializeAO<AO_JSON_file>(FileName.OpenRead(), encoding);}
        public void DeserializeAO(FileInfo[] Files, Encoding encoding)
        { foreach (FileInfo file in Files)
            { DeserializeAO(file, encoding); }
        }
        public void DeserializeAO<T>(Stream stream,Encoding encoding) where T:AO_JSON_file
        {
            Logger.Info("Запущено преобразование AO");
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.Converters.Add(new geoPolyConverter_file());
            jss.Culture = CultureInfo.CurrentCulture;
            
            T[] json_data = JsonConvert.DeserializeObject<T[]>((new StreamReader(stream, encoding)).ReadToEnd(),jss);
            Logger.Info("Преобразовано AO");
            JS.AOs.Create<AO>();
            List<AO> data = new List<AO>();
            foreach (T jitem in json_data)
            {
                AO ditem = new AO();
                ditem.ADRES = jitem.ADRES;
                if (jitem.DDOC !=null) { ditem.DDOC = DateTime.Parse(jitem.DDOC, CultureInfo.CurrentCulture); }
                ditem.DMT = jitem.DMT;
                if (jitem.DREG != null) { ditem.DREG = DateTime.Parse(jitem.DREG, CultureInfo.CurrentCulture); }
                if (jitem.geoData != null)
                {
                    List<string> pointlist = new List<string>();
                    List<string> polygonlist = new List<string>();
                    var c = jitem.geoData.coordinates;
                    switch (jitem.geoData.Type)
                    {
                        case "Point":
                            break;
                        case "Polygon":
                            geoPolygon polygonList = (geoPolygon)jitem.geoData.coordinates;
                            string Pstr = "POLYGON "+(polygonList.ToString());
                            try { ditem.geoData = DbGeography.PolygonFromText(Pstr, 4326); }
                            catch (TargetInvocationException e)
                            {
                                Logger.Warn("Неправильное направление обхода точек в объекте POLYGON", e);
                                polygonList.Reverse();
                                Pstr = "POLYGON " + (polygonList.ToString()); }
                            break;
                        case "MultiPolygon":
                            geoMPolygon MpolygonList = (geoMPolygon)jitem.geoData.coordinates;
                            string MPstr = "MULTIPOLYGON " + (MpolygonList.ToString());
                            try
                            {
                                ditem.geoData = DbGeography.MultiPolygonFromText(MPstr, 4326);
                            }
                            catch (TargetInvocationException e)
                            {
                                Logger.Warn("Неправильное направление обхода точек в объекте MULTIPOLYGON", e);
                                MpolygonList.Reverse();
                                MPstr = "MULTIPOLYGON " + (MpolygonList.ToString());

                            }
                            break;
                    }
                }
                else ditem.geoData = null;
                ditem.global_id = jitem.global_id;
                ditem.KAD_KV = jitem.KAD_KV;
                ditem.KAD_RN = jitem.KAD_RN;
                ditem.KAD_ZU = jitem.KAD_ZU;
                ditem.NDOC = jitem.NDOC;
                ditem.NREG = jitem.NREG;
                ditem.SOOR = jitem.SOOR;
                ditem.STRT = jitem.STRT;
                ditem.system_object_id = jitem.system_object_id;
                ditem.TDOC = jitem.TDOC;
                ditem.UNOM = jitem.UNOM;
                ditem.VLD = jitem.VLD;
                ditem.VYVAD = jitem.VYVAD;
                ditem.KRT = jitem.KRT;
                data.Add(ditem);
            }
            JS.AOs.AddRange(data);
            JS.SaveChanges();
            Logger.Info("Сохранено AO");
        }

        public void DeserializeAO_site(Stream stream, Encoding encoding)
        {
            Logger.Info("Запущено преобразование AO");
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.Converters.Add(new geoPolyConverter_site());
            jss.Culture = CultureInfo.CurrentCulture;

            AO_JSON_site[] json_data = JsonConvert.DeserializeObject<AO_JSON_site[]>((new StreamReader(stream, encoding)).ReadToEnd(), jss);
            Logger.Info("Преобразовано AO");
            JS.AOs.Create<AO>();
            List<AO> data = new List<AO>();
            foreach (AO_JSON_site jitem in json_data)
            {
                AO ditem = new AO();
                ditem.ADRES = jitem.Cells.ADRES;
                if (jitem.Cells.DDOC != null) { ditem.DDOC = DateTime.Parse(jitem.Cells.DDOC, CultureInfo.CurrentCulture); }
                ditem.DMT = jitem.Cells.DMT;
                if (jitem.Cells.DREG != null) { ditem.DREG = DateTime.Parse(jitem.Cells.DREG, CultureInfo.CurrentCulture); }
                if (jitem.Cells.geoData != null)
                {
                    try
                    {
                        ditem.geoData = DbGeography.FromText(jitem.Cells.geoData.AsText(), 4326);
                    }
                    catch { ditem.geoData = DbGeography.FromText(jitem.Cells.geoData.Reverse().AsText(), 4326); }
                    
                }
                else ditem.geoData = null;
                ditem.global_id = jitem.Cells.global_id;
                ditem.KAD_KV = jitem.Cells.KAD_KV;
                ditem.KAD_RN = jitem.Cells.KAD_RN;
                ditem.KAD_ZU = jitem.Cells.KAD_ZU;
                ditem.NDOC = jitem.Cells.NDOC;
                ditem.NREG = jitem.Cells.NREG;
                ditem.SOOR = jitem.Cells.SOOR;
                ditem.STRT = jitem.Cells.STRT;
                //ditem.system_object_id = jitem.Cells.system_object_id;
                ditem.TDOC = jitem.Cells.TDOC;
                ditem.UNOM = jitem.Cells.UNOM;
                ditem.VLD = jitem.Cells.VLD;
                ditem.VYVAD = jitem.Cells.VYVAD;
                ditem.KRT = jitem.Cells.KRT;
                data.Add(ditem);
            }
            JS.AOs.AddRange(data);
            JS.SaveChanges();
            Logger.Info("Сохранено AO");
        }
        public void DeserializeAO(Encoding encoding)
        {
            Loader.dataset = "1927";
            Loader.Load(encoding);
            // foreach (string S in Loader.Result)
            string S;
            while (Loader.Result.TryDequeue(out S))
            {
                MemoryStream ms = new MemoryStream(encoding.GetBytes(S));
                DeserializeAO_site(ms, encoding);
            }
        }
        public void LoadGeoJSON_AO(Stream stream, Encoding encoding)
        {
            // = "E:\\Filetable1\\ao.geojson";

            var s = new StreamReader(stream, encoding).ReadToEnd();

            var reader = new GeoJsonReader();
            var fc = reader.Read<FeatureCollection>(s);
            List<AO_geojson> flist = new List<AO_geojson>();
            foreach (Feature f in fc.Features)
            {

                var geo = f.Geometry.AsText();
                AO_geojson AO = new AO_geojson();
                AO.NAME = (string)f.Attributes["NAME"];
                AO.OKATO = (string)f.Attributes["OKATO"];
                AO.ABBREV = (string)f.Attributes["ABBREV"];
                try
                {
                    AO.geometry = DbGeography.FromText(f.Geometry.AsText(), 4326);
                }
                catch
                {
                    try
                    {
                        AO.geometry = DbGeography.FromText(f.Geometry.Reverse().AsText(), 4326);
                    }
                    catch {
                        AO.geometry = null;
                        
                    }

                }
                flist.Add(AO);
            }
                JS.Configuration.AutoDetectChangesEnabled = false;
                JS.AO_geojsons.AddRange(flist);
                JS.SaveChanges();
                JS.Configuration.AutoDetectChangesEnabled = true;
            }

        public void LoadGeoJSON_MO(Stream stream, Encoding encoding)
        {
            // = "E:\\Filetable1\\ao.geojson";

            var s = new StreamReader(stream, encoding).ReadToEnd();

            var reader = new GeoJsonReader();
            var fc = reader.Read<FeatureCollection>(s);
            List<MO_geojson> flist = new List<MO_geojson>();
            foreach (Feature f in fc.Features)
            {

                var geo = f.Geometry.AsText();
                MO_geojson MO = new MO_geojson();
                MO.NAME = (string)f.Attributes["NAME"];
                MO.OKATO = (string)f.Attributes["OKATO"];
                MO.ABBREV_AO = (string)f.Attributes["ABBREV_AO"];
                MO.OKTMO = (string)f.Attributes["OKTMO"];
                MO.NAME_AO = (string)f.Attributes["NAME_AO"];
                MO.OKATO_AO = (string)f.Attributes["OKATO_AO"];
                MO.TYPE_MO = (string)f.Attributes["TYPE_MO"];
                try
                {
                    MO.geometry = DbGeography.FromText(f.Geometry.AsText(), 4326);
                }
                catch
                {
                    try
                    {
                        MO.geometry = DbGeography.FromText(f.Geometry.Reverse().AsText(), 4326);
                    }
                    catch
                    {
                        MO.geometry = null;

                    }

                }
                flist.Add(MO);
            }
            JS.Configuration.AutoDetectChangesEnabled = false;
            JS.MO_geojsons.AddRange(flist);
            JS.SaveChanges();
            JS.Configuration.AutoDetectChangesEnabled = true;
        }
    }
    }

