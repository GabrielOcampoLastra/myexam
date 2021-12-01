using Newtonsoft.Json;
using Realms;

namespace MyExam.Models
{
    public class Picture : RealmObject
    {
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
