using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OnThisDay.WPFClient.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.WPFClient.ViewModels.TodayEventItem
{
    public class TodayEventViewModel : ViewModelBase
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }

        public RelayCommand<string> ShowSelectedEventCommand { get; set; }

        public Messenger ShowEventDetailMessage { get; set; }

        public TodayEventViewModel()
        {
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            ShowSelectedEventCommand = new RelayCommand<string>((selectedEventId) =>
            {
                Messenger.Default.Send(new ShowEventDetailMessage(selectedEventId));
            });
        }
    }
}
