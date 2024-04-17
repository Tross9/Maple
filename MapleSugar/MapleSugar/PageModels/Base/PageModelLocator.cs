using System;
using System.Collections.Generic;
using System.Text;
using MapleSugar.Services.Navigation;
using MapleSugar.Pages;
using MapleSugar.Services;
//using MapleSugar.Services.Account;
//using MapleSugar.Services.Statement;
//using MapleSugar.Services.Work;
//using MapleSugar.Models;
using TinyIoC;
using Xamarin.Forms;

namespace MapleSugar.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            //  Register pages and page models
            Register<SplashPageModel, SplashPage>();
            Register<CheckListPageModel, CheckListPage>();
            Register<CollectionPageModel, CollectionPage>();
            Register<MenuPageModel, MenuPage>();            
            Register<TreeInfoPageModel, TreeInfoPage>();


            // Register services (services are registered as Singletons default)
            _container.Register<INavigationService, NavigationService>();

        }

        public static T Resolve<T>() where T : class 
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}
