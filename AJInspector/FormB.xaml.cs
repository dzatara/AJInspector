﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using System.Linq;
using Xamarin.Forms;



namespace AJInspector
{
    public partial class FormB : ContentPage
    {


        public FormB()
        {
            InitializeComponent();
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

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        void FormC_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FormC());
        }


        void CarFront_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarFront.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0.3);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
        }

        void CarFL3_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarFL3_4.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0.3);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
        }

        void CarLTop_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarLTop.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0.3);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
        }

        void CarSide_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarSide.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0.3);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
        }

        void CarRL3_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarRL3_4.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0.3);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
        }

        void CarRear_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarRear.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0.3);
            b7.BackgroundColor = new Color(255, 255, 255, 0);
        }

        void CarRR3_Clicked(object sender, System.EventArgs e)
        {
            //DisplayAlert("Car Front clicked", "Clik Yo!", "OK");
            thumb.Source = "CarRR3_4.png";
            b1.BackgroundColor = new Color(255, 255, 255, 0);
            b2.BackgroundColor = new Color(255, 255, 255, 0);
            b3.BackgroundColor = new Color(255, 255, 255, 0);
            b4.BackgroundColor = new Color(255, 255, 255, 0);
            b5.BackgroundColor = new Color(255, 255, 255, 0);
            b6.BackgroundColor = new Color(255, 255, 255, 0);
            b7.BackgroundColor = new Color(255, 255, 255, 0.3);
        }

        void ToggleMarker_Clicked(object sender, System.EventArgs e)
        {
            if ((markerImage.Source != null))
            {
                markerImage.Source = null;
            }
            else
            {
                markerImage.Source = "marker.png";
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
            }

        }
    }
}
