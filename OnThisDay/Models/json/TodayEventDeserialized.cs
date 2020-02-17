﻿using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.WPFClient.Models.json
{
    [JsonObject("todayevendeserialized")]
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
