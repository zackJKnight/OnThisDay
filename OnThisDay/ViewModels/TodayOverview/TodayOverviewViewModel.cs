using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using OnThisDay.Providers;
using OnThisDay.ViewModels.TodayEventItem;
using System;
using System.Collections.ObjectModel;
using Grpc.Core;
using Grpc.Net.Client;
using OnThisDay.TodayEvents.Protos;

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
            string ServerAddress = "http://localhost:44360";
            string TODAYS_EVENTS_ID = "e317e7a4-2afd-4859-b2cc-da707a726e66";

        var channel = GrpcChannel.ForAddress(ServerAddress);
            var todayEvents = new TodayEvents.Protos.TodayEvents.TodayEventsClient(channel);

            try
            {
                var request = new GetAllRequest
                {
                    TodayEventListId = TODAYS_EVENTS_ID
                };
                var response = await todayEvents.GetAllAsync(request);
                foreach (var todayEvent in response.Today.TodayEvents)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        TodayEventViewModels.Add(new TodayEventViewModel()
                        {
                            Name = todayEvent.Name,
                            Description = todayEvent.Description,
                            Detail = todayEvent.Details
                        });
                    });
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
