using Newtonsoft.Json;
using OnThisDay.Models;
using OnThisDay.ViewModels.TodayOverview;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.Providers
{
    public class TodayEventDataProvider : IDataProvider
    {
        private const string DATA_FILE = @"./Resources/MockEvents.json";

        public List<TodayEvent> TodayEvents { get; set; }

        public TodayEventDataProvider()
        {
            TodayEvents = new List<TodayEvent>();
        }

        public async Task<TodayEvent> GetTodayEventByName(string name)
        {
            if(!TodayEvents.Any())
            {
                await GetEventsFromFileAsync().ConfigureAwait(false);
            }
            return TodayEvents.Where(todayEvent => todayEvent.Name == name).FirstOrDefault();
        }

        public async Task<IEnumerable<TodayEvent>> GetEventsFromFileAsync()
        {
            var deserializedJsonEvents = await Task.Run(() =>
             {
                 using (StreamReader reader = File.OpenText(DATA_FILE))
                 {
                     string json = reader.ReadToEnd();
                     return JsonConvert.DeserializeObject<RootEventCollection>(json);
                 }
             });

            foreach (var deserializedEvent in deserializedJsonEvents.Events)
            {
                TodayEvents.Add(
                    new TodayEvent()
                    {
                        Name = deserializedEvent.Name,
                        Description = deserializedEvent.Description,
                        Detail = deserializedEvent.Detail
                    });
            }

            return TodayEvents;
        }
    }
}
