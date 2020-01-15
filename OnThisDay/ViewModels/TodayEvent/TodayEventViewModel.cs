using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.ViewModels.TodayEvent
{
    public class TodayEventViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }
        public string Description { get; set; }
        public string Detail { get; set; }
        public TodayEventViewModel()
        {
            //SetPropertyValues();
        }

        private async void SetPropertyValues()
        {
            this.Name = await GetNameFromService();
        }

        private async Task<string> GetNameFromService()
        {
            return await new Task<string>(() => "hi");        
        }
    }

}
