using Newtonsoft.Json;
using System.Collections.Generic;

namespace TiburonTest.Domain.Models
{
    public class SurveyUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("пол")]
        public string Gender { get; set; }

        [JsonProperty("телефоны")]
        public string PhoneBrands { get; set; }
    }
}
