using System;
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
        [Required]
        public string PresidentName { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Birth_year { get; set; }
        public int? Death_year { get; set; }
        public DateTime TookOffice { get; set; }
        public DateTime? LeftOffice { get; set; }
        public string Party { get; set; }
    }
}
