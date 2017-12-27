
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Microcharts.Forms;
using Microcharts.Droid;
using Microcharts;
using SkiaSharp;
using SignaturePad;
using System;

namespace AJInspector
{
    public partial class FormD : ContentPage
    {
        //DECLARATIONS
        int vId;
        private DataStore ReportData;

        int Total;
        int A1;
        int B1;
        int C1;
        int D1;

        public ObservableCollection<Detail> RecentDetail { get; set; }
        public ObservableCollection<Vehicle> CurrentVehicle { get; set; }
        public ObservableCollection<Mechanical> MechDetail { get; set; }
        public ObservableCollection<Report> ReportDetail { get; set; }

        //FormD or Report
        public FormD(int vID, int total, int A, int B, int C, int D)
        {
            InitializeComponent();

            ReportData = new DataStore("Inspector");
            vId = vID;
            Total = total;
            A1 = A;
            B1 = B;
            C1 = C;
            D1 = D;


        }

        //OnAppearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.ReportData;


            ShowVehicle();
            ShowDetail();
            ShowMechanical();


            var chartSeries = new[]
            {
                 new Microcharts.Entry (A1)
                 {
                    Label = "Condition score: 100-75",
                    ValueLabel = MakeAPercentage(A1, Total),
                     Color = SKColor.Parse("#00D83E")
                 },
                 new Microcharts.Entry (B1)
                 {
                    Label = "Condition score: 75-50",
                    ValueLabel = MakeAPercentage(B1, Total),
                    Color = SKColor.Parse("#FFD64A")
                 },
                 new Microcharts.Entry (C1)
                 {
                    Label = "Condition score: 50-25",
                    ValueLabel = MakeAPercentage(C1, Total),
                    Color = SKColor.Parse("#FF7700")
                 },
                 new Microcharts.Entry (D1)
                 {
                    Label = "Condition score: 25-0",
                    ValueLabel = MakeAPercentage(D1, Total),
                     Color = SKColor.Parse("#D30D1B")
                 }
             };

            this.MechanicalChart.Chart = new DonutChart { Entries = chartSeries };

        }

        //ShowVehicle
        void ShowVehicle()
        {
            try
            {
                CurrentVehicle = new ObservableCollection<Vehicle>(ReportData.GetVehicle(vId));
                TheVehicle.ItemsSource = CurrentVehicle;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DisplayAlert("Oops", "No Vehicle in List", "OK");
            }
        }

        //ShowDetail
        void ShowDetail()
        {
            try
            {
                RecentDetail = new ObservableCollection<Detail>(ReportData.GetAllDetails(vId));
                int count = RecentDetail.Count;
                NewDetail.ItemsSource = RecentDetail;
                NewDetail.HeightRequest = (count * 65);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DisplayAlert("Detail Inspection", "No detail record Found", "OK");
            }
        }

        //ShowMechanical
        void ShowMechanical()
        {
            try
            {
                MechDetail = new ObservableCollection<Mechanical>(ReportData.GetAllMechanicals(vId));
                MechInspect.ItemsSource = MechDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DisplayAlert("Detail Inspection", "No detail record Found", "OK");
            }
        }

        //MakeAPercentage
        string MakeAPercentage(int x, int total)
        {
            double x1 = x;
            double t = total;

            double fraction = x1 / t;
            fraction = Math.Round(fraction * 100, 1);
            string result = fraction + "%";
            return result;
        }
    }
}
