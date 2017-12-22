using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


using Xamarin.Forms;

namespace AJInspector
{
    public partial class MenuPage : ContentPage
    {

        private DataStore database;
        public ObservableCollection<Vehicle> RecentList { get; set; }


        public MenuPage()
        {
            InitializeComponent();


            database = new DataStore("Inspector");
            database.CreateTable<Vehicle>();
            database.CreateTable<Report>();
            database.CreateTable<Detail>();
            database.CreateTable<Mechanical>();

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            // DisplayAlert("Database - 'Inspector'", "Database and tables created succesfully", "OK");
            DisplayAlert("Database", "Database now contains: " + database.FindNumberRecords() + " Vehicle Entries", "OK");
            this.BindingContext = this.database;

            RecentList = new ObservableCollection<Vehicle>(database.GetAllVehicles());
            var RList = database.GetAllVehicles();

            if (RecentList != null)
            {
                NewVehicles.ItemsSource = RecentList;
            }
            else
            {
                DisplayAlert("Oops", "No Vehicles in List", "ok");

            }

        }

        void Find_SearchButtonPressed(object sender, System.EventArgs e)
        {
            DisplayAlert("seach", "click registered in search", "OK");
            //open card showing records matching search or display data not found message
        }

        void FormA_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new FormA());
            //Application.Current.MainPage = new AJInspectorPage { Detail = new NavigationPage(new FormA()) };

        }

        void AddVehicle_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new VehicleForm());
            //Application.Current.MainPage = new AJInspectorPage {Detail = new NavigationPage()}
        }
    }
}
