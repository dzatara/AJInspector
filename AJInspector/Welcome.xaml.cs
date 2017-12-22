using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AJInspector
{
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        void Find_SearchButtonPressed(object sender, System.EventArgs e)
        {
            DisplayAlert("seach", "click registered in search", "OK");
            //open card showing records matching search or display data not found message
        }

        void FormA_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FormA());

        }
        void AddVehicle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new VehicleForm());

        }
    }
}
