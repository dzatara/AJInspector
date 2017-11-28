using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AJInspector
{
    public partial class FormC : ContentPage
    {
        public FormC()
        {
            InitializeComponent();
        }

        void FormD_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FormD());
        }
    }
}
