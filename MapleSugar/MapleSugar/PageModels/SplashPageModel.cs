using MapleSugar.PageModels.Base;
using MapleSugar.Services.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace MapleSugar.PageModels
{
    public class SplashPageModel : PageModelBase
    {
        private ICommand _splashScreenCommand;

        public ICommand SplashScreenCommand
        {
            get => _splashScreenCommand;
            set => SetProperty(ref _splashScreenCommand, value);
        }

        private INavigationService _navigationService;
        public SplashPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SplashScreenCommand = new Command(OnSplashPageAction);
        }

        private async void OnSplashPageAction(object ogj)
        {
            await _navigationService.NavigateToAsync<MenuPageModel>();            
        }
    }
}

