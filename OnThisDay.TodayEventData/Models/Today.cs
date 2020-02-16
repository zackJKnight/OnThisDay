using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.TodayEventData.Models
{
    public class Today
    {
        public int Id { get; set; }
        public Guid TodayEventListId { get; set; }
        public List<TodayEvent> TodayEventList { get; set; }

    }
}
