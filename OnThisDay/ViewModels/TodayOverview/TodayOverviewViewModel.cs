using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OnThisDay.WPFClient.Providers;
using OnThisDay.WPFClient.ViewModels.TodayEventItem;
using System;
using System.Collections.ObjectModel;
using Grpc.Core;
using Grpc.Net.Client;
using OnThisDay.TodayEvents.Protos;
using System.Threading.Tasks;

namespace OnThisDay.WPFClient.ViewModels.TodayOverview
{
    public class TodayOverviewViewModel : ViewModelBase
    {
        private ObservableCollection<TodayEventViewModel> _todayEventViewModels = new ObservableCollection<TodayEventViewModel>();

        private IDataProvider _fileEventDataProvider;
        private string _title;
        private bool _dataProviderErrorIsVisible;
        private string _dataProviderErrorMessage;
        private object _dataProviderDefaultErrorMessage;

        public TodayOverviewViewModel()
        {
            Title = "Choose an Event From This Day in History";
            _dataProviderDefaultErrorMessage = "There's a problem getting the requested data!";
            _dataProviderErrorIsVisible = false;
            _fileEventDataProvider = new TodayEventDataProvider();
            RegisterCommands();
        }

        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }
        public ObservableCollection<TodayEventViewModel> TodayEventViewModels
        {
            get { return _todayEventViewModels; }
            private set { Set(() => TodayEventViewModels, ref _todayEventViewModels, value); }
        }

        public RelayCommand LoadEventsCommand { get; set; }
        public bool DataProviderErrorIsVisible
        {
            get { return _dataProviderErrorIsVisible; }
            private set { Set(() => DataProviderErrorIsVisible, ref _dataProviderErrorIsVisible, value); }
        }

        public string DataProviderErrorMessage
        {
            get { return _dataProviderErrorMessage; }
            private set { Set(() => DataProviderErrorMessage, ref _dataProviderErrorMessage, value);  }
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
            try
            {
                var loadedEvents = await _fileEventDataProvider.GetEventsFromFileAsync().ConfigureAwait(false);

                foreach (var todayEvent in loadedEvents)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        TodayEventViewModels.Add(new TodayEventViewModel
                        {

                            Description = todayEvent.Description,
                            Detail = todayEvent.Detail,
                            Name = todayEvent.Name
                        });
                    });
                }
            }
            catch(NullReferenceException nullEx)
            {
                Console.WriteLine(nullEx.Message);
            }
            //await Task.Run(() => _fileEventDataProvider.GetTodayEventByName("")).ConfigureAwait(true);
        }
    }
}
