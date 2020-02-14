using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.TodayEventData.Models
{
    public interface ITodayEventRepository
    {
        Task<TodayEvent> GetTodayEventByNameAsync(string name);

        Task<IEnumerable<TodayEvent>> GetEventsFromFileAsync(string todaysEventsIds);

    }
}
