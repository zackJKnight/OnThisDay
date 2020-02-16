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
             
                //Id = source.Id,
                //TodayEventListId = source.TodayEventListId.ToString() //,
                //TodayEvents.AddRange(source.TodayEvents);
            };

//            target.TodayEvents.AddRange(source.TodayEvents.Select(TodaysEvents.FromRepositoryModel));

            return target;
        }
    }
}
