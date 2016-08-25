using MapKit;
using UnlockNativeFormsSample;
using UnlockNativeFormsSample.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyMap), typeof(MyMapRenderer))]

namespace UnlockNativeFormsSample.iOS
{
    public class MyMapRenderer : MapRenderer
    {
        private MyMap _xamarinMap;

        protected MKMapView NativeMap
        {
            get
            {
                return Control as MKMapView;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _xamarinMap = e.NewElement as MyMap;

                NativeMap.RegionChanged += NativeMap_RegionChanged;
            }
        }

        private void NativeMap_RegionChanged(object sender, MKMapViewChangeEventArgs e)
        {
            // This
            if (_xamarinMap.OnRegionChanged != null)
                _xamarinMap.OnRegionChanged();

            // or this
            MessagingCenter.Send<object>(this, "RegionChanged");
        }
    }
}