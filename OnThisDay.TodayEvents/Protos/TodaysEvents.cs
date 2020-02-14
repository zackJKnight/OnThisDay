using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnThisDay.TodayEventData.Models;

namespace OnThisDay.TodayEvents.Protos
{
    public partial class TodaysEvents
    {
        public static TodaysEvents FromRepositoryModel(OnThisDay.TodayEventData.Models.TodaysEvents source)
        {
            if (source is null) return null;

            var target = new TodaysEvents
            {
                Id = source.Id,
                TodaysEventsId = source.TodaysEventsId.ToString() //,
                //TodayEvents.AddRange(source.TodayEvents);
            };

//            target.TodayEvents.AddRange(source.TodayEvents.Select(TodaysEvents.FromRepositoryModel));

            return target;
        }
    }
}
