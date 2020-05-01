using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CodingXoriant
{
    public class President
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonProperty("president")]
        public string PresidentName { get; set; }
        public int Number { get; set; }
        public int Birth_year { get; set; }
        public int? Death_year { get; set; }
    }
}
