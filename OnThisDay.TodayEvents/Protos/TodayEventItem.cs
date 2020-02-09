using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.TodayEvents.Protos
{
    class TodayEventItem
    {
        public static TodayEventItem FromRepositoryModel(TodayEventData.Models.TodayEventItem source)
        {
            if (source is null) return null;

            return new TodayEventItem
            {

            };
        }
    }
}
