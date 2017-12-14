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
