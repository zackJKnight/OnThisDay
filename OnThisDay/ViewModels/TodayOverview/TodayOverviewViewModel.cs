using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OnThisDay.Providers;
using OnThisDay.ViewModels.TodayEventItem;
using System;
using System.Collections.ObjectModel;

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
            private set { Set(() => TodayEventViewModels, ref _todayEventViewModels, value); }
        }

        public RelayCommand LoadEventsCommand { get; set; }

        public TodayOverviewViewModel()
        {
            Title = "Choose an Event From This Day in History";
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
            foreach (var todayEvent in await _fileEventDataProvider.GetEventsFromFileAsync().ConfigureAwait(false))
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    TodayEventViewModels.Add(new TodayEventViewModel()
                    {
                        Name = todayEvent.Name,
                        Description = todayEvent.Description,
                        Detail = todayEvent.Detail
                    });
                });
            }
        }
    }
}
