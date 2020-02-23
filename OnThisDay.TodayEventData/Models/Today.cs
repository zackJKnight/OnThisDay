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

        public Today()
        {
            TodayEventList = new List<TodayEvent>();
            TodayEventListId = new Guid("e317e7a4-2afd-4859-b2cc-da707a726e66");
        }

    }
}
