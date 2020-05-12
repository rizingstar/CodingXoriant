using System;
using Newtonsoft.Json;

namespace CodingXoriant.Model
{
    public class PresidentDTO
    {
        [JsonProperty("president")]
        public string PresidentName { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("birth_year")]
        public int Birth_year { get; set; }
        [JsonProperty("death_year")]
        public int? Death_year { get; set; }
        [JsonProperty("took_office")]
        public DateTime TookOffice { get; set; }
        [JsonProperty("left_office")]
        public DateTime LeftOffice { get; set; }
        [JsonProperty("party")]
        public int? Party { get; set; }
    }
}
