using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using OnThisDay.Models;
using OnThisDay.Models.json;
using OnThisDay.ViewModels.TodayEvent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace OnThisDay.ViewModels.TodayOverview
{
    public class TodayOverviewViewModel : ViewModelBase
    {
        private const string DATA_FILE = @"./Resources/MockEvents.json";
        private ObservableCollection<TodayEventViewModel> _todayEventViewModels = new ObservableCollection<TodayEventViewModel>();

        public string Title { get; set; }
        public ObservableCollection<TodayEventViewModel> TodayEventViewModels
        {
            get { return _todayEventViewModels; }
            set { Set(() => TodayEventViewModels, ref _todayEventViewModels, value); }
        }

        public TodayOverviewViewModel()
        {
            Title = "Hi, From Master VM!";

            LoadEvents();

        }

        private void LoadEvents()
        {
            using (StreamReader reader = File.OpenText(DATA_FILE))
            {
                string json = reader.ReadToEnd();
                var deserializedJsonEvents = JsonConvert.DeserializeObject<RootObject>(json);
                foreach (var todayEvent in deserializedJsonEvents.Events)
                {
                    _todayEventViewModels.Add(
                        new TodayEventViewModel()
                        {
                            Name = todayEvent.Name,
                            Description = todayEvent.Description
                        });
                }
            }
        }
    }
}
