﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.TodayEventData.Models
{
    public class TodayEventRepository : ITodayEventRepository
    {
        private const string DATA_FILE = @"./Resources/MockEvents.json";

        public List<TodayEvent> TodayEvents { get; }

        public TodayEventRepository()
        {
            TodayEvents = new List<TodayEvent>();
        }
        public async Task<TodayEvent> GetTodayEventByNameAsync(string name)
        {
            if (!TodayEvents.Any())
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
            }).ConfigureAwait(false);

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
