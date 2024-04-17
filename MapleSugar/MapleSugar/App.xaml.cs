using System.Threading.Tasks;
using MapleSugar.PageModels;
using MapleSugar.PageModels.Base;
using MapleSugar.Services.Navigation;
using Xamarin.Forms;

namespace MapleSugar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // MainPage = new MainPage();
        }

        private Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<SplashPageModel>(null, true);
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
