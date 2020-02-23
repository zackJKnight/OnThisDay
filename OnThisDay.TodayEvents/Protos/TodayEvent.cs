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

            return new TodayEvent
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Detail = source.Detail
            };
        }
    }
}
