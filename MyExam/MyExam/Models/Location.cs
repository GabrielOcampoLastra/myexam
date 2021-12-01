using Newtonsoft.Json;
using Realms;

namespace MyExam.Models
{
    public class Location : RealmObject
    {
        [JsonProperty("street")]
        public Street Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        public string UserPosition { get; set; }
    }
}