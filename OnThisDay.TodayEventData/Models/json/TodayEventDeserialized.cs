using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace OnThisDay.TodayEventData.Models.json
{
    [JsonObject()]
    public class TodayEventDeserialized : ObservableObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }

    }
}
