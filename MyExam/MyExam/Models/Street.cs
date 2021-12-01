using Newtonsoft.Json;
using Realms;

namespace MyExam.Models
{
    public class Street : RealmObject
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} {Number}";
        }
    }
}