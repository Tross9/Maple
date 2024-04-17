using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MapleSugar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilePickerPage : ContentPage
    {
        public FilePickerPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(Object sender, EventArgs e)
        {
            try
            {
                // var PickResult = await FilePicker.PickAsync(new PickOptions
                var file = await FilePicker.PickAsync();

                    if (file != null)
                    {
                        LabelInfo.Text = file.FileName;
                    }
            }
            catch (Exception)
            {
                   
            }
        }
     }
}

