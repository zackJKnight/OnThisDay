using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using OnThisDay.WPFClient.Models.json;

namespace OnThisDay.WPFClient.ViewModels.TodayOverview
{
    internal class RootEventCollection
    {
        [JsonProperty(PropertyName = "Events")]
        public TodayEventDeserialized[] Events { get; set; }
    
    }
}
