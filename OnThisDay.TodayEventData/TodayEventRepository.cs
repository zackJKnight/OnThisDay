using Newtonsoft.Json;
using OnThisDay.TodayEventData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.TodayEventData
{
    public class TodayEventRepository : ITodayEventRepository
    {
        private const string DATA_FILE = @"./Resources/MockEvents.json";
        public Today Today { get; }

        public TodayEventRepository()
        {
            Today = new Today();
        }
        public async Task<TodayEvent> GetTodayEventByNameAsync(string name)
        {
            if (!Today.TodayEventList.Any())
            {
                await GetEventsFromFileAsync(name).ConfigureAwait(false);
            }
            return Today.TodayEventList.Where(todayEvent => todayEvent.Name == name).FirstOrDefault();
        }

        public async Task<Today> GetEventsFromFileAsync(string todayEventListId)
        {
            var deserializedJsonEvents = await Task.Run(() =>
            {
                using (StreamReader reader = File.OpenText(DATA_FILE))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<RootEventCollection>(json);
                }
            }).ConfigureAwait(false);

            foreach (var deserializedEvent in deserializedJsonEvents.Events)
            {
                Today.TodayEventList.Add(
                    new TodayEvent()
                    {
                        Name = deserializedEvent.Name,
                        Description = deserializedEvent.Description,
                        Detail = deserializedEvent.Detail
                    });
            }

            return Today;
        }
    }
}
