
using OnThisDay.WPFClient.Providers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnThisDay.WPFClient.Providers
{
    public interface IDataProvider
    {
        Task<TodayEventLookup> GetTodayEventByName(string name);

        Task<IEnumerable<TodayEventLookup>> GetEventsFromFileAsync();

        Task<IEnumerable<TodayEventLookup>> DownloadHeadlinesAsync(int selectedYear);

    }
}