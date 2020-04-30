using Newtonsoft.Json;

namespace CodingXoriant
{
    public class President
    {
        [JsonProperty("president")]
        public string PresidentName { get; set; }
        public int Number { get; set; }
        public int Birth_year { get; set; }
        public int? Death_year { get; set; }
    }
}
