using System;
using System.Collections.Generic;
using System.Text;
using OnThisDay.TodayEventData.Models.json;

namespace OnThisDay.TodayEventData.Models
{
    public class TodayEvent : TodayEventDeserialized
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

    }
}
