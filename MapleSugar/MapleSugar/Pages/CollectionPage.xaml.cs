using Xamarin.Forms;
using Xamarin.Forms.Xaml;
// <Button Text="{Binding SaveDataButtonText}" />
namespace MapleSugar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            InitializeComponent();
        }
    }
}