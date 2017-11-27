using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AJInspector
{
    public partial class AJInspectorPage : MasterDetailPage
    {
        public AJInspectorPage()
        {
            InitializeComponent();
            //Detail = new Welcome();
            IsPresented = false;

        }

        void FormA_Clicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new FormA());
            IsPresented = false;

        }
    }

}
