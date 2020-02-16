using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnThisDay.TodayEventData.Models;

namespace OnThisDay.TodayEvents.Protos
{
    public partial class Today
    {
        public static Today FromRepositoryModel(TodayEventData.Models.Today source)
        {
            if (source is null) return null;

            var target = new Today

            {
                Id = source.Id,
                TodayEventListId = source.TodayEventListId.ToString()
            };

            source.TodayEventList.ToList()
.ForEach(item => target.TodayEvents.Add(new TodayEvent
{
    Id = item.Id,
    Name = item.Name,
    Description = item.Description,
    Details = item.Details
}))
;

            return target;
        }
    }
}
