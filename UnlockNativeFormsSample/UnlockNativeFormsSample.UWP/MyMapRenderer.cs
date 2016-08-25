using UnlockNativeFormsSample;
using UnlockNativeFormsSample.UWP;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MyMap), typeof(MyMapRenderer))]

namespace UnlockNativeFormsSample.UWP
{
    public class MyMapRenderer : MapRenderer
    {
        private MyMap _xamarinMap;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _xamarinMap = e.NewElement as MyMap;

                Control.ActualCameraChanged += Control_ActualCameraChanged;
            }
        }

        private void Control_ActualCameraChanged(MapControl sender, MapActualCameraChangedEventArgs args)
        {
            // This
            if (_xamarinMap.OnRegionChanged != null)
                _xamarinMap.OnRegionChanged();

            // or this
            MessagingCenter.Send<object>(this, "RegionChanged");
        }
    }
}