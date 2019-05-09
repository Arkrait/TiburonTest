using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TiburonTest.Resources
{
    public class SaveSurveyUserResource
    {
        [Required]
        [JsonProperty("пол")]
        public string Gender { get; set; }

        [Required]
        [JsonProperty("телефоны")]
        public List<string> PhoneBrands { get; set; }
    }
}
