using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AJInspector
{
    public class Vehicle : INotifyPropertyChanged
    {

        [PrimaryKey, AutoIncrement]
        public int VehicleID { get; set; }


        public string DateIn { get; set; }

        public string Inspector { get; set; }

        public string VIN { get; set; }

        public string VReg { get; set; }

        public string VType { get; set; }

        public string Make { get; set; }

        public string MfYear { get; set; }

        public string VModel { get; set; }

        public string EngCap { get; set; }

        public string VTrans { get; set; }

        public string Wheels { get; set; }

        public string Odo { get; set; }

        public string Driver { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        public override string ToString()
        {
            return string.Format("[Vehicle: VehicleID={0}, DateIn={1}, Inspector={2}, VIN={3}, VReg={4}, VType={5}, Make={6}, MfYear={7}, VModel={8}, EngCap={9}, VTrans={10}, Wheels={11}, Odo={12}, Driver={13}, Email={14}, Tel={15}]", VehicleID, DateIn, Inspector, VIN, VReg, VType, Make, MfYear, VModel, EngCap, VTrans, Wheels, Odo, Driver, Email, Tel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static implicit operator ObservableCollection<object>(Vehicle v)
        {
            throw new NotImplementedException();
        }
    }

    public class Report
    {
        [PrimaryKey, AutoIncrement]
        public int ReportID { get; set; }

        public int VID { get; set; }

        [OneToMany]
        public List<Detail> Details { get; set; }

        public int MID { get; set; }

        public string InspectorSign { get; set; }

        public string DriverSign { get; set; }

        public override string ToString()
        {
            return string.Format("[Report: ReportID={0}, VID={1}, Details={2}, MID={3}, InspectorSign={4}, DriverSign={5}]", ReportID, VID, Details, MID, InspectorSign, DriverSign);
        }


    }

    public class Detail
    {
        [PrimaryKey, AutoIncrement]
        public int DetailID { get; set; }

        [ForeignKey(typeof(Report))]
        public int VID { get; set; }

        public string Orientation { get; set; }

        public string Picture { get; set; }

        public string IssueDetail { get; set; }

        public override string ToString()
        {
            return string.Format("[Detail: DetailID={0}, VID={1}, Orientation={2}, Picture={3}, IssueDetail={4}]", DetailID, VID, Orientation, Picture, IssueDetail);
        }
    }

    public class Mechanical
    {
        [PrimaryKey, AutoIncrement]
        public int MID { get; set; }

        [ForeignKey(typeof(Report))]
        public int VID { get; set; }

        public string EngineOilLevel { get; set; }

        public string EngineOilQuality { get; set; }

        public string CoolantLevel { get; set; }

        public string WasherFluidLevel { get; set; }

        public string IgnitionSystem { get; set; }

        public string Compressor { get; set; }

        public string FrontSuspension { get; set; }

        public string BreakPad { get; set; }

        public string FrontTyre { get; set; }

        public string RearTyre { get; set; }

        public string FrontFogLamps { get; set; }

        public string MainHeadLamps { get; set; }

        public string BreakLamps { get; set; }

        public string Trafficindicator { get; set; }

        public string Cabinlights { get; set; }

        public string BootLamps { get; set; }

        public string FrontSeatBelt { get; set; }

        public string RearSeatBelts { get; set; }

        public string Upholstry { get; set; }

        public string SeatAdjustment { get; set; }

        public string ClimateControl { get; set; }

        public string Radio { get; set; }

        public override string ToString()
        {
            return string.Format("[Mechanical: MID={0}, VID={1}, EngineOilLevel={2}, EngineOilQuality={3}, CoolantLevel={4}, WasherFluidLevel={5}, IgnitionSystem={6}, Compressor={7}, FrontSuspension={8}, BreakPad={9}, FrontTyre={10}, RearTyre={11}, FrontFogLamps={12}, MainHeadLamps={13}, BreakLamps={14}, Trafficindicator={15}, Cabinlights={16}, BootLamps={17}, FrontSeatBelt={18}, RearSeatBelts={19}, Upholstry={20}, SeatAdjustment={21}, ClimateControl={22}, Radio={23}]", MID, VID, EngineOilLevel, EngineOilQuality, CoolantLevel, WasherFluidLevel, IgnitionSystem, Compressor, FrontSuspension, BreakPad, FrontTyre, RearTyre, FrontFogLamps, MainHeadLamps, BreakLamps, Trafficindicator, Cabinlights, BootLamps, FrontSeatBelt, RearSeatBelts, Upholstry, SeatAdjustment, ClimateControl, Radio);
        }


    }
}

