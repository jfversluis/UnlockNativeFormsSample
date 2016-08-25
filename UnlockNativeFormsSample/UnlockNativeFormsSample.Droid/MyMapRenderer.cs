using Android.Gms.Maps;
using UnlockNativeFormsSample;
using UnlockNativeFormsSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyMap), typeof(MyMapRenderer))]

namespace UnlockNativeFormsSample.Droid
{
    public class MyMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        private MyMap _xamarinMap;
        private GoogleMap _googleMap;

        public virtual void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;

            _googleMap.CameraChange += _googleMap_CameraChange;
        }

        private void _googleMap_CameraChange(object sender, GoogleMap.CameraChangeEventArgs e)
        {
            // This
            if (_xamarinMap.OnRegionChanged != null)
                _xamarinMap.OnRegionChanged();

            // or this
            MessagingCenter.Send<object>(this, "RegionChanged");
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                _xamarinMap = e.NewElement as MyMap;
        }
    }
}