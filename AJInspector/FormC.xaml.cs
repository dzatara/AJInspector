using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AJInspector
{
    public partial class FormC : ContentPage
    {
        //DECLARATIONS
        int vId;
        private DataStore MechanicalData;

        public ObservableCollection<Detail> RecentDetail { get; set; }
        public ObservableCollection<Vehicle> CurrentVehicle { get; set; }

        public int total = 22;
        public int hundredToSeventy = 0;
        public int seventyToFifty = 0;
        public int fiftyToTwenty = 0;
        public int TwentyToZero = 0;

        //FormmC
        public FormC(int vID)
        {
            InitializeComponent();
            MechanicalData = new DataStore("Inspector");
            vId = vID;

        }

        //OnAppearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.MechanicalData;

            ShowVehicle();

        }

        //ShowVehicle
        void ShowVehicle()
        {
            CurrentVehicle = new ObservableCollection<Vehicle>(MechanicalData.GetVehicle(vId));

            if (CurrentVehicle != null)
            {
                TheVehicle.ItemsSource = CurrentVehicle;
            }
            else
            {
                DisplayAlert("Oops", "No Vehicle in List", "ok");
            }
        }

        //FormD_Clicked
        void FormD_Clicked(object sender, System.EventArgs e)
        {
            if (Radio.Items[Radio.SelectedIndex] == null)
            {

                DisplayAlert("Tut Tut!", "Skipping Checks Aai!? Please choose a rating for each item", "OK");

            }
            else
            {
                string engineOilLevel = EngineOilLevel.Items[EngineOilLevel.SelectedIndex];
                EvalRecord(engineOilLevel);
                string engineOilQuality = EngineOilQuality.Items[EngineOilQuality.SelectedIndex];
                EvalRecord(engineOilQuality);
                string coolantLevel = CoolantLevel.Items[CoolantLevel.SelectedIndex];
                EvalRecord(coolantLevel);
                string washerFluid = WasherFluidLevel.Items[WasherFluidLevel.SelectedIndex];
                EvalRecord(washerFluid);
                string ignition = IgnitionSystem.Items[IgnitionSystem.SelectedIndex];
                EvalRecord(ignition);
                string compressor = Compressor.Items[Compressor.SelectedIndex];
                EvalRecord(compressor);

                string frontSus = FrontSuspension.Items[FrontSuspension.SelectedIndex];
                EvalRecord(frontSus);
                string breakPad = BreakPadCondition.Items[BreakPadCondition.SelectedIndex];
                EvalRecord(breakPad);
                string frontTyre = FrontTyreCondition.Items[FrontTyreCondition.SelectedIndex];
                EvalRecord(frontTyre);
                string rearTyre = RearTyreCondition.Items[RearTyreCondition.SelectedIndex];
                EvalRecord(rearTyre);

                string frontFogs = FrontFogLamps.Items[FrontFogLamps.SelectedIndex];
                EvalRecord(frontFogs);
                string mainHeadlamps = MainHeadlamps.Items[MainHeadlamps.SelectedIndex];
                EvalRecord(mainHeadlamps);
                string breakLamps = BreakLamps.Items[BreakLamps.SelectedIndex];
                EvalRecord(breakLamps);
                string traffiCator = TrafficIndicatorLamps.Items[TrafficIndicatorLamps.SelectedIndex];
                EvalRecord(traffiCator);
                string cabinLight = CabinLights.Items[CabinLights.SelectedIndex];
                EvalRecord(cabinLight);
                string bootLights = BootLights.Items[BootLights.SelectedIndex];
                EvalRecord(bootLights);

                string frontBelt = FrontSeatBelts.Items[FrontSeatBelts.SelectedIndex];
                EvalRecord(frontBelt);
                string rearBelt = RearSeatBelts.Items[RearSeatBelts.SelectedIndex];
                EvalRecord(rearBelt);
                string upholstry = Upholstry.Items[Upholstry.SelectedIndex];
                EvalRecord(upholstry);
                string seatAdjust = SeatAdjustmentMechanism.Items[SeatAdjustmentMechanism.SelectedIndex];
                EvalRecord(seatAdjust);
                string climateControl = ClimateControl.Items[ClimateControl.SelectedIndex];
                EvalRecord(climateControl);
                string radio = Radio.Items[Radio.SelectedIndex];
                EvalRecord(radio);

                var record = new Mechanical
                {
                    VID = vId,
                    EngineOilLevel = engineOilLevel,
                    EngineOilQuality = engineOilQuality,
                    CoolantLevel = coolantLevel,
                    WasherFluidLevel = washerFluid,
                    IgnitionSystem = ignition,
                    Compressor = compressor,
                    FrontSuspension = frontSus,
                    BreakPad = breakPad,
                    FrontTyre = frontTyre,
                    RearTyre = rearTyre,
                    FrontFogLamps = frontFogs,
                    MainHeadLamps = mainHeadlamps,
                    BreakLamps = breakLamps,
                    Trafficindicator = traffiCator,
                    Cabinlights = cabinLight,
                    BootLamps = bootLights,
                    FrontSeatBelt = frontBelt,
                    RearSeatBelts = rearBelt,
                    Upholstry = upholstry,
                    SeatAdjustment = seatAdjust,
                    ClimateControl = climateControl,
                    Radio = radio
                };

                MechanicalData.SaveItem(record, 0);

                Navigation.PushAsync(new FormD(vId, total, hundredToSeventy, seventyToFifty, fiftyToTwenty, TwentyToZero));

            }
        }

        private void EvalRecord(string record)
        {
            switch (record)
            {
                case "100 - 75":
                    hundredToSeventy += 1;
                    break;
                case "75 - 50":
                    seventyToFifty += 1;
                    break;
                case "50 - 25":
                    fiftyToTwenty += 1;
                    break;
                case "25 - 0":
                    TwentyToZero += 1;
                    break;
            }
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = sender as Picker;
            switch (picker.SelectedIndex)
            {
                case 0:
                    picker.BackgroundColor = Color.Green;
                    break;
                case 1:
                    picker.BackgroundColor = Color.Yellow;
                    break;
                case 2:
                    picker.BackgroundColor = Color.Orange;
                    break;
                case 3:
                    picker.BackgroundColor = Color.Red;
                    break;
            }
        }
    }
}
