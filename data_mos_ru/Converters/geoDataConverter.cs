using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using data_mos_ru.Entityes;
using System.Data.Entity.Spatial;
using Microsoft.SqlServer.Types;
using data_mos_ru.Converters;

namespace data_mos_ru
{
    class geoDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(geoData));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            geoData geo = new geoData();
            if (obj.Properties().Where(p => p.Name.StartsWith("center")).Any())
            {
                geo.Сenter = BtiGeoDeserializer.Point(obj.Properties().Where(p => p.Name.StartsWith("center")).First());
            }
            if (obj.Properties().Where(p => p.Name.StartsWith("type")).Any())
            {
                geo.Type = (string)obj["type"];
                switch (geo.Type)
                {
                    case "Point":
                        {
                            geo.Coordinates = BtiGeoDeserializer.Point(obj.Properties().Where(p => p.Name.StartsWith("coordinates")).First());
                            break;
                        }
                    case "Polygon":
                        {
                            geo.Coordinates = BtiGeoDeserializer.Polygon(obj.Properties().Where(p => p.Name.StartsWith("coordinates")).First());
                            break;
                        }
                    case "MultiPolygon":
                        {
                            geo.Coordinates = BtiGeoDeserializer.MPolygon(obj.Properties().Where(p => p.Name.StartsWith("coordinates")).First());
                            break;
                        }
                    default: { throw new JsonSerializationException("Unrecognized type: geo"); }
                };
            }
            //if (geo.Type != null || geo.Coordinates != null || geo.Сenter !=null)
            return geo;
            //else { return null; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
