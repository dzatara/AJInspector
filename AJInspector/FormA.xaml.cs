using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AJInspector
{
    public partial class FormA : ContentPage
    {
        public FormA()
        {
            InitializeComponent();
        }

        void FormB_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FormB());
            //Application.Current.MainPage.IsPresented = false;
        }
    }
}
