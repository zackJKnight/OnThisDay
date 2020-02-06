using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using OnThisDay.Models.json;

namespace OnThisDay.ViewModels.TodayOverview
{
    internal class RootEventCollection
    {
        [JsonProperty(PropertyName = "Events")]
        public TodayEventDeserialized[] Events { get; set; }
    
    }
}
