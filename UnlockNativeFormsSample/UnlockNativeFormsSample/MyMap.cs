using Xamarin.Forms.Maps;

namespace UnlockNativeFormsSample
{
    public class MyMap : Map
    {
        public delegate void OnRegionChangedDelegate();

        public OnRegionChangedDelegate OnRegionChanged { get; set; }
    }
}