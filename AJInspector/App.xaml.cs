using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AJInspector
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
        MasterDetailPage masterdetail;
        Page detailpage;
        Page masterpage;


        public App()
        {
            InitializeComponent();
            masterdetail = new AJInspectorPage();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = masterdetail;
            else
                MainPage = masterdetail;

        }

        protected override void OnStart()
        {

            masterpage = masterdetail.Master;
            detailpage = masterdetail.Detail;
            MainPage = masterdetail;
        }


    }
}
