using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnThisDay.ViewModels.TodayEvent
{
    public class TodayEventViewModel : ViewModelBase
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public TodayEventViewModel()
        {
        }

    }

}
