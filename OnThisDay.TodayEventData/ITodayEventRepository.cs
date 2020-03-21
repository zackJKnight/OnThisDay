using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnThisDay.TodayEventData.Models;

namespace OnThisDay.TodayEventData
{
    public interface ITodayEventRepository
    {
        Task<TodayEvent> GetTodayEventByNameAsync(string name);

        Task<Today> GetEventsFromFileAsync();

    }
}
