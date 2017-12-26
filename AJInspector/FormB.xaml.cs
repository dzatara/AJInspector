using System;
using Plugin.Media;
using System.Collections.ObjectModel;
using Xamarin.Forms;



namespace AJInspector
{
    public partial class FormB : ContentPage
    {
        string picLocation;
        string angle;
        string dlocation;
        int vId;

        //DECLARATIONS
        private DataStore detailData;

        public ObservableCollection<Detail> RecentDetail { get; set; }
        public ObservableCollection<Vehicle> CurrentVehicle { get; set; }


        //FromB
        public FormB(int vID)
        {
            InitializeComponent();
            detailData = new DataStore("Inspector");
            vId = vID;

            #region Take a picture
            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "AJInspect",
                    Name = "AJI_" + DateTime.Now.ToString("MM/dd/yyyy") + ".jpg"
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");
                picLocation = file.Path;

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
            #endregion
        }

        //OnAppearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.detailData;

            ShowVehicle();
            ShowDetail();
        }

        //ShowVehicle
        void ShowVehicle()
        {
            CurrentVehicle = new ObservableCollection<Vehicle>(detailData.GetVehicle(vId));

            if (CurrentVehicle != null)
            {
                TheVehicle.ItemsSource = CurrentVehicle;
            }
            else
            {
                DisplayAlert("Oops", "No Vehicle in List", "ok");
            }
        }

        //AddDetail_Clicked
        void AddDetail_Clicked(object sender, System.EventArgs e)
        {
            if (detailInfo.Text == null || detailInfo.Text == "Enter defect detail here")
            {
                DisplayAlert("No detail added", "Sorry! detail is blank! We need you to add notes to proceed", "OK");
            }
            else
            {
                var filename = angle + "_markerImage" + dlocation + ".jpg";
                var record = new Detail
                {
                    VID = vId,
                    Orientation = filename,
                    Picture = picLocation,
                    IssueDetail = detailInfo.Text,

                };

                detailData.SaveItem(record, 0);


                ShowDetail();
                ClearFormB();
            }
        }

        //ShowDetail
        void ShowDetail()
        {
            try
            {
                RecentDetail = new ObservableCollection<Detail>(detailData.GetAllDetails(vId));
                NewDetail.ItemsSource = RecentDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DisplayAlert("New Report", "Proceed to perform a detail inspection of the chosen vehicle", "OK");
            }
        }

        //FormC_Clicked
        void FormC_Clicked(object sender, System.EventArgs e)
        {
            if (detailInfo.Text == null || detailInfo.Text == "Enter defect detail here")
            {

                DisplayAlert("No Detail added", "Sorry! You cant add a blank form! We need you to fill out some notes to proceed", "OK");

            }
            else
            {
                var filename = angle + "_markerImage" + dlocation + ".jpg";
                var record = new Detail
                {
                    VID = vId,
                    Orientation = filename,
                    Picture = picLocation,
                    IssueDetail = detailInfo.Text,

                };

                detailData.SaveItem(record, 0);


                int lastid = detailData.GetLastid();


                DisplayAlert("+ Detail", "Detail record " + lastid + " added succesfully", "OK");


                Navigation.PushAsync(new FormC(vId));
            }
        }

        //ClearFormB
        void ClearFormB()
        {
            detailInfo.Text = "";
            image.Source = "";
        }

        void CarFront_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            #region CarFront icon selection
            thumb.Source = "CarFront.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0.3);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
            angle = "CarFront";
            #endregion
        }

        void CarFL3_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front left 3/4 clicked", "Clik Yo!", "OK");
            #region Car Front Left 3/4 icon selection
            thumb.Source = "CarFL3_4.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0.3);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
            angle = "CarFL3_4";
            #endregion
        }

        void CarLTop_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Left Top clicked", "Clik Yo!", "OK");
            #region Car Left Top icon selection
            thumb.Source = "CarLTop.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0.3);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
            angle = "CarLTop";
            #endregion
        }

        void CarSide_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Side clicked", "Clik Yo!", "OK");
            #region Car Side icon selection
            thumb.Source = "CarSide.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0.3);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
            angle = "CarSide";
            #endregion
        }

        void CarRL3_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Right Lower third clicked", "Clik Yo!", "OK");
            #region Car Right Lower third icon selection
            thumb.Source = "CarRL3_4.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0.3);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
            angle = "CarRL3_4";
            #endregion
        }

        void CarRear_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Rear clicked", "Clik Yo!", "OK");
            #region Car Rear icon selection
            thumb.Source = "CarRear.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0.3);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
            angle = "CarRear";
            #endregion
        }

        void CarRR3_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Right Rear 3/4 clicked", "Clik Yo!", "OK");
            #region Car Right Rear 3/4 icon selection
            thumb.Source = "CarRR3_4.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0.3);
            angle = "CarRR3_4";
            #endregion
        }

        #region Marker toggle methods
        void ToggleMarker_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage.Source != null))
            {
                markerImage.Source = null;
            }
            else
            {
                markerImage.Source = "marker.png";
                dlocation = "0";
            }

        }
        void ToggleMarker1_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage1.Source != null))
            {
                markerImage1.Source = null;
            }
            else
            {
                markerImage1.Source = "marker.png";
                dlocation = "1";
            }

        }
        void ToggleMarker2_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage2.Source != null))
            {
                markerImage2.Source = null;
            }
            else
            {
                markerImage2.Source = "marker.png";
                dlocation = "2";
            }

        }
        void ToggleMarker3_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage3.Source != null))
            {
                markerImage3.Source = null;
            }
            else
            {
                markerImage3.Source = "marker.png";
                dlocation = "3";
            }

        }
        void ToggleMarker4_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage4.Source != null))
            {
                markerImage4.Source = null;
            }
            else
            {
                markerImage4.Source = "marker.png";
                dlocation = "4";
            }

        }
        void ToggleMarker5_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage5.Source != null))
            {
                markerImage5.Source = null;
            }
            else
            {
                markerImage5.Source = "marker.png";
                dlocation = "5";
            }

        }
        void ToggleMarker6_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage6.Source != null))
            {
                markerImage6.Source = null;
            }
            else
            {
                markerImage6.Source = "marker.png";
                dlocation = "6";
            }

        }
        void ToggleMarker7_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage7.Source != null))
            {
                markerImage7.Source = null;
            }
            else
            {
                markerImage7.Source = "marker.png";
                dlocation = "7";
            }

        }
        void ToggleMarker8_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage8.Source != null))
            {
                markerImage8.Source = null;
            }
            else
            {
                markerImage8.Source = "marker.png";
                dlocation = "8";
            }

        }
        void ToggleMarker9_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage9.Source != null))
            {
                markerImage9.Source = null;
            }
            else
            {
                markerImage9.Source = "marker.png";
                dlocation = "9";
            }

        }
        void ToggleMarker10_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage10.Source != null))
            {
                markerImage10.Source = null;
            }
            else
            {
                markerImage10.Source = "marker.png";
                dlocation = "10";
            }

        }
        void ToggleMarker11_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage11.Source != null))
            {
                markerImage11.Source = null;
            }
            else
            {
                markerImage11.Source = "marker.png";
                dlocation = "11";
            }

        }
        void ToggleMarker12_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage12.Source != null))
            {
                markerImage12.Source = null;
            }
            else
            {
                markerImage12.Source = "marker.png";
                dlocation = "12";
            }

        }
        void ToggleMarker13_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage13.Source != null))
            {
                markerImage13.Source = null;
            }
            else
            {
                markerImage13.Source = "marker.png";
                dlocation = "13";
            }

        }
        void ToggleMarker14_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage14.Source != null))
            {
                markerImage14.Source = null;
            }
            else
            {
                markerImage14.Source = "marker.png";
                dlocation = "14";
            }

        }
        void ToggleMarker15_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage15.Source != null))
            {
                markerImage15.Source = null;
            }
            else
            {
                markerImage15.Source = "marker.png";
                dlocation = "15";
            }

        }
        void ToggleMarker16_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage16.Source != null))
            {
                markerImage16.Source = null;
            }
            else
            {
                markerImage16.Source = "marker.png";
                dlocation = "16";
            }

        }
        void ToggleMarker17_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage17.Source != null))
            {
                markerImage17.Source = null;
            }
            else
            {
                markerImage17.Source = "marker.png";
                dlocation = "17";
            }

        }
        void ToggleMarker18_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage18.Source != null))
            {
                markerImage18.Source = null;
            }
            else
            {
                markerImage18.Source = "marker.png";
                dlocation = "18";
            }

        }
        void ToggleMarker19_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage19.Source != null))
            {
                markerImage19.Source = null;
            }
            else
            {
                markerImage19.Source = "marker.png";
                dlocation = "19";
            }

        }
        void ToggleMarker20_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage20.Source != null))
            {
                markerImage20.Source = null;
            }
            else
            {
                markerImage20.Source = "marker.png";
                dlocation = "20";
            }

        }
        void ToggleMarker21_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage21.Source != null))
            {
                markerImage21.Source = null;
            }
            else
            {
                markerImage21.Source = "marker.png";
                dlocation = "21";
            }

        }
        void ToggleMarker22_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage22.Source != null))
            {
                markerImage22.Source = null;
            }
            else
            {
                markerImage22.Source = "marker.png";
                dlocation = "22";
            }

        }
        void ToggleMarker23_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage23.Source != null))
            {
                markerImage23.Source = null;
            }
            else
            {
                markerImage23.Source = "marker.png";
                dlocation = "23";
            }

        }
        void ToggleMarker24_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage24.Source != null))
            {
                markerImage24.Source = null;
            }
            else
            {
                markerImage24.Source = "marker.png";
                dlocation = "24";
            }

        }
        #endregion
    }
}
