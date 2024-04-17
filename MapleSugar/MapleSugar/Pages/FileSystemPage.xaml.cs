
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapleSugar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileSystemPage : ContentPage
    {
        // static global vars
        public static string OutputFileName = "";
        public static string localPath = "";
        public static string CollectionHeader = "";


        public FileSystemPage()
        {
            InitializeComponent();
        }

        private void Load(object sender, EventArgs e)
        {
            OpenFileAction();
        }

        private async void OpenFileAction()
        // private async void Button_Clicked(Object sender, EventArgs e)
        {
            // var PickResult = await FilePicker.PickAsync(new PickOptions
            var CurrentFile = await FilePicker.PickAsync();

            if (CurrentFile != null)
            {
                OutputFileName = CurrentFile.FullPath;

                bool doesexists = File.Exists(OutputFileName);

                if (doesexists)
                {
                    CurrentContents.Text = File.ReadAllText(OutputFileName);
                }
                else
                {
                    CurrentContents.Text = " No File Found For Collection Data";
                }
            }
        }
    }
}