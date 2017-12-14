using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AJInspector
{
    public partial class AJInspectorPage : MasterDetailPage
    {
        private DataStore database;

        public AJInspectorPage()
        {
            InitializeComponent();
            IsPresented = false;

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
            //this.BindingContext = this.database;
        }

        void Find_SearchButtonPressed(object sender, System.EventArgs e)
        {
            DisplayAlert("seach", "click registered in search", "OK");
            //open card showing records matching search or display data not found message
        }

        void FormA_Clicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new FormA());
            IsPresented = false;

        }

        void AddVehicle_Clicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new VehicleForm());
            IsPresented = false;

        }
    }

}
