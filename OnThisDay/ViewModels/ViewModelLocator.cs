using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using OnThisDay.WPFClient.Providers;
using OnThisDay.WPFClient.ViewModels.Main;
using OnThisDay.WPFClient.ViewModels.TodayEventDetail;
using OnThisDay.WPFClient.ViewModels.TodayEventItem;
using OnThisDay.WPFClient.ViewModels.TodayOverview;

namespace OnThisDay.WPFClient.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register(() => new MainViewModel());
            SimpleIoc.Default.Register(() => new TodayEventDataProvider());
            SimpleIoc.Default.Register<IDataProvider, TodayEventDataProvider>();
            SimpleIoc.Default.Register(() => new TodayEventViewModel());
            SimpleIoc.Default.Register(() => new TodayEventDetailViewModel());
            SimpleIoc.Default.Register(() => new TodayOverviewViewModel());
        }

        /// <summary>
        /// Gets the Main VM.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        /// <summary>
        /// Gets the TodayEvent property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TodayEventViewModel TodayEventViewModel => ServiceLocator.Current.GetInstance<TodayEventViewModel>();

        /// <summary>
        /// Gets the TodayEventDetail.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TodayEventDetailViewModel TodayEventDetailViewModel => ServiceLocator.Current.GetInstance<TodayEventDetailViewModel>();

        /// <summary>
        /// Gets the TodayOverviewViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TodayOverviewViewModel TodayOverviewViewModel => ServiceLocator.Current.GetInstance<TodayOverviewViewModel>();

    }
}
