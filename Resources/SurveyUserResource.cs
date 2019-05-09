using System.Collections.Generic;
using Newtonsoft.Json;

namespace TiburonTest.Resources
{
    public class SurveyUserResource
    {
        public int Id { get; set; }

	[JsonProperty("пол")]
	public string Gender { get; set; }

	[JsonProperty("телефоны")]
	public List<string> PhoneBrands { get; set; }
    }
}
