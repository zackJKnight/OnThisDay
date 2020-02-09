using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using OnThisDay.TodayEventData.Models.json;

namespace OnThisDay.TodayEventData.Models
{
    internal class RootEventCollection
    {
        [JsonProperty(PropertyName = "Events")]
        public TodayEventDeserialized[] Events { get; set; }
    
    }
}
