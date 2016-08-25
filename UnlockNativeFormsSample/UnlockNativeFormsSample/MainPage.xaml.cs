using Xamarin.Forms;

namespace UnlockNativeFormsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // This
            MyAwesomeMap.OnRegionChanged += OnRegionChangedHandler;

            // Or this
            MessagingCenter.Subscribe<object>(this, "RegionChanged", (o) =>
            {
                // Handle region changed here
            });
        }

        private void OnRegionChangedHandler()
        {
            MyAwesomeLabel.Text = $"{MyAwesomeMap.VisibleRegion.Center.Latitude}, {MyAwesomeMap.VisibleRegion.Center.Longitude}";
        }
    }
}