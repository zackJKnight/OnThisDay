using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.Models.json
{
    public class TodayEventDeserialized : ObservableObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }
        //public DateTime Date { get; set; }
    }
}
