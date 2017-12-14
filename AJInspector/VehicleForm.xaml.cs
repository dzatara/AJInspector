using System;

using System.Json;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;


namespace AJInspector
{
    public partial class VehicleForm : ContentPage
    {
        private DataStore vehicleData;

        public string DateIn { get; set; }
        public ObservableCollection<Vehicle> Vehicles { get; set; }


        public VehicleForm()
        {
            InitializeComponent();
            Dtoday.Date = DateTime.Today;
            vehicleData = new DataStore("Inspector");

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //this.BindingContext = this.vehicleData;
        }

        #region VIN lookup api call

        void VIN_PropertyChangedAsync(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Query external Data for VIN and display values
            string TheVIN = ((Entry)sender).Text;
            string url = "https://api.edmunds.com/api/inventory/v2/vins/" + TheVIN + "?fmt=json";

            //JsonValue json = FetchDetailsAsync(url).Result;
            //ParseAndDisplay(json);
        }

        private async Task<JsonValue> FetchDetailsAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonValue.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    return jsonDoc;
                }
            }
        }

        private void ParseAndDisplay(JsonValue json)
        {
            //deconstruct json result
            JsonValue VehicleMake = json["make"];
            VMake.Text = VehicleMake["name"];

            JsonValue VehicleModel = json["model"];
            VModel.Text = VehicleModel["name"];

            JsonValue Vehicleyear = json["year"];
            MfYear.Text = Vehicleyear["year"];

            JsonValue VehicleType = json["style"];
            JsonValue VehicleType0 = VehicleType["submodel"];
            VType.SelectedItem = VehicleType0["body"];

        }

        #endregion

        void Save_Clicked(object sender, System.EventArgs e)
        {
            string vtype = VType.Items[VType.SelectedIndex];
            string vtrans = VTrans.Items[VTrans.SelectedIndex];
            string wheels = Wheels.Items[Wheels.SelectedIndex];

            var record = new Vehicle
            {
                DateIn = Dtoday.Date.ToString(),
                Inspector = Inspector.Text,
                VIN = VIN.Text,
                VType = vtype,
                Make = VMake.Text,
                MfYear = MfYear.Text,
                VModel = VModel.Text,
                EngCap = EngCap.Text,
                VTrans = vtrans,
                Wheels = wheels,
                Odo = Odo.Text,
                Driver = Driver.Text,
                Email = Email.Text,
                Tel = Tel.Text
            };

            vehicleData.SaveItem(record, 0);
            DisplayAlert("+ Vehicle", VMake.Text + " with driver " + Driver.Text + " added succesfully", "OK");
            Navigation.PushModalAsync(new AJInspectorPage());

        }
    }
}
