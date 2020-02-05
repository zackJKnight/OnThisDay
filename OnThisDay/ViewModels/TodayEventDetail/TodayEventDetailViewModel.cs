using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OnThisDay.Messaging;
using OnThisDay.Providers;
using OnThisDay.ViewModels.TodayEvent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OnThisDay.ViewModels.TodayEventDetail
{
    public class TodayEventDetailViewModel : ViewModelBase
    {
        public bool IsVisible { get; set; }

        public string Description { get; set; }

        private IDataProvider _todayEventDataProvider;

        private TodayEventViewModel _selectedEvent;

        public TodayEventViewModel SelectedEvent
        {
            get { return _selectedEvent; }
            set { Set(() => _selectedEvent, ref _selectedEvent, value); }
        }

        public TodayEventDetailViewModel()
        {
            Description = string.Empty;
            SelectedEvent = new TodayEventViewModel();

            _todayEventDataProvider = new TodayEventDataProvider();
            RegisterMessages();
        }

        private async void RegisterMessages()
        {
            Messenger.Default.Register<ShowEventDetailMessage>(this, async e =>
            {
                var selectedTodayEvent = await _todayEventDataProvider.GetTodayEventByName(e.Name);
                SelectedEvent.Name = selectedTodayEvent.Name;
                Description = selectedTodayEvent.Description;
                SelectedEvent.Detail = selectedTodayEvent.Detail;
                IsVisible = true;
            });
        }
    }

}
