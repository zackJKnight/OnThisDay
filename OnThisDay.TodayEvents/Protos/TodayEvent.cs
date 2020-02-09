using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.TodayEvents.Protos
{
    public partial class TodayEvent
    {
        public static TodayEvent FromRepositoryModel(TodayEventData.Models.TodayEvent source)
        {
            if (source is null) return null;

            var target = new TodayEvent
            {

                Name = source.Name,
                Description = source.Description,
            };

            target.TodayEvents.AddRange(source.TodayEvents.Select(TodayEventItem.FromRepositoryModel));

            return target;
        }
    }
}
