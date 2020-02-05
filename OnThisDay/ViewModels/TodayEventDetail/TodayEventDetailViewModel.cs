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

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }
        public string Description {
            get { return _description; }
            set { Set(() => Description, ref _description, value); }
        }
        public string Detail
        {
            get { return _detail; }
            set { Set(() => Detail, ref _detail, value); }
        }

        private IDataProvider _todayEventDataProvider;

        private TodayEventViewModel _selectedEvent;
        private string _description;
        private string _detail;
        private string _name;

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
                Name = selectedTodayEvent.Name;
                Description = selectedTodayEvent.Description;
                Detail = selectedTodayEvent.Detail;
                IsVisible = true;
            });
        }
    }

}
