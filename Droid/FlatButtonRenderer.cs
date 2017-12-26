using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using AJInspector.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(FlatButtonRenderer))]
namespace AJInspector.Droid
{
    public class FlatButtonRenderer : ButtonRenderer
    {
        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
        }
    }
}
