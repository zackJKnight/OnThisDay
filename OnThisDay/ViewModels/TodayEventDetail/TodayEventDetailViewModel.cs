using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OnThisDay.Messaging;
using OnThisDay.Providers;

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

        public IDataProvider TodayEventDataProvider { get; }

        private string _description;
        private string _detail;
        private string _name;

        public TodayEventDetailViewModel()
        {
            Description = string.Empty;

            TodayEventDataProvider = new TodayEventDataProvider();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<ShowEventDetailMessage>(this, async e =>
            {
                //var selectedTodayEvent = await TodayEventDataProvider.GetTodayEventByName(e.Name).ConfigureAwait(false);
                //Name = selectedTodayEvent.Name;
                //Description = selectedTodayEvent.Description;
                //Detail = selectedTodayEvent.Detail;
                IsVisible = true;
            });
        }
    }

}
