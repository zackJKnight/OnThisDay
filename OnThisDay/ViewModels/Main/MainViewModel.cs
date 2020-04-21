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
using OnThisDay.WPFClient.Providers;
using GalaSoft.MvvmLight.Ioc;

namespace OnThisDay.WPFClient.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            TodayEventDataProvider = SimpleIoc.Default.GetInstance<IDataProvider>();
            RegisterCommands();
        }

        public IDataProvider TodayEventDataProvider { get; private set; }
        public RelayCommand DownloadHeadlinesAsyncCommand { get; set; }

        private void RegisterCommands()
        {
            DownloadHeadlinesAsyncCommand = new RelayCommand(() =>
            {
                //TodayEventDataProvider.DownloadHeadlinesAsync();
            });
        }

        
    }
}
