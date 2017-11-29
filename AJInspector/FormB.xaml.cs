using System;
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
    }
}
