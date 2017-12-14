using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AJInspector
{
    public partial class AJInspectorPage : MasterDetailPage
    {


        public AJInspectorPage()
        {
            this.Master = new MenuPage();
            this.Detail = new NavigationPage(new Welcome());

            InitializeComponent();
            IsPresented = false;

        }

    }

}
