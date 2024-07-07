using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegradorAsaas.Tools
{
    public class CustomDateConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.Value != null && reader.Value.ToString() == "0000-00-00")
            {
                // Trate datas inválidas como DateTime.MinValue ou outra lógica adequada ao seu caso
                return DateTime.MinValue;
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

    }
}
