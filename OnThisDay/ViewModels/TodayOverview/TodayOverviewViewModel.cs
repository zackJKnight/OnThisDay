using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using OnThisDay.Messaging;
using OnThisDay.Models;
using OnThisDay.Models.json;
using OnThisDay.Providers;
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
        private ObservableCollection<TodayEventViewModel> _todayEventViewModels = new ObservableCollection<TodayEventViewModel>();

        private IDataProvider _fileEventDataProvider;
        private string _title;

        public string Title {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }
        public ObservableCollection<TodayEventViewModel> TodayEventViewModels
        {
            get { return _todayEventViewModels; }
            set { Set(() => TodayEventViewModels, ref _todayEventViewModels, value); }
        }

        public RelayCommand LoadEventsCommand { get; set; }

        public TodayOverviewViewModel()
        {
            Title = "Hi, From the Master View Model!";
            _fileEventDataProvider = new TodayEventDataProvider();
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            LoadEventsCommand = new RelayCommand(() =>
            {
                LoadEvents();
            });

        }

        private async void LoadEvents()
        {
            foreach (var todayEvent in await _fileEventDataProvider.GetEventsFromFileAsync())
            {
                TodayEventViewModels.Add(new TodayEventViewModel()
                {
                    Name = todayEvent.Name,
                    Description = todayEvent.Description,
                    Detail = todayEvent.Detail
                });
            }
        }
    }
}
