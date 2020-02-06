using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using OnThisDay.Providers;
using OnThisDay.ViewModels.TodayEventDetail;
using OnThisDay.ViewModels.TodayEventItem;
using OnThisDay.ViewModels.TodayOverview;

namespace OnThisDay.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register(() => new TodayEventDataProvider());
            SimpleIoc.Default.Register<IDataProvider, TodayEventDataProvider>();
            SimpleIoc.Default.Register(() => new TodayEventViewModel());
            SimpleIoc.Default.Register(() => new TodayEventDetailViewModel());
            SimpleIoc.Default.Register(() => new TodayOverviewViewModel());
        }

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
