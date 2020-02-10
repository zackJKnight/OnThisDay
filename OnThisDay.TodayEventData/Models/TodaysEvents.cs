using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.TodayEventData.Models
{
    public class TodaysEvents
    {
        public int Id { get; set; }
        public Guid TodaysEventsId { get; set; }
        public List<TodayEvent> TodayEvents { get; set; }

    }
}
