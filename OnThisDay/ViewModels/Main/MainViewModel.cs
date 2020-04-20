using Grpc.Core;
using Grpc.Net.Client;
using OnThisDay.TodayEvents.Protos;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OnThisDay.WPFClient.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.WPFClient.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        private static int _selectedYear = 1980;

        public RelayCommand DownloadHeadlinesAsyncCommand { get; set; }

        public MainViewModel()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            DownloadHeadlinesAsyncCommand = new RelayCommand(() =>
            {
                DownloadHeadlinesAsync();
            });
        }

        private static async void DownloadHeadlinesAsync()
        {
            string ServerAddress = Environment.GetEnvironmentVariable("SERVER_ADDRESS");

            var channel = GrpcChannel.ForAddress(ServerAddress);
            var headlineClient = new HeadlineService.HeadlineServiceClient(channel);

            try
            {
                var request = new DownloadRequest();
                request.Year = _selectedYear;

                var response = await headlineClient.DownloadHeadlinesAsync(request);

            }
            catch
            {
                throw;
            }
        }
    }
}
