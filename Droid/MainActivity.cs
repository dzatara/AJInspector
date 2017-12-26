using Android.App;
using Android.Content;
using Android.Content.PM;

using Android.OS;
using Plugin.Media;
using XLabs.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace AJInspector.Droid
{
    [Activity(Label = "AC Inspector", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity//XFormsApplicationDroid 
    {



        protected override async void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            await CrossMedia.Current.Initialize();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());


        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

        }



    }
}
