using MapleSugar.Models;
using MapleSugar.PageModels.Base;
using MapleSugar.ViewModels.Buttons;
using System.Collections.ObjectModel;
using MvvmHelpers;
using MapleSugar.Services;
using System.Linq;
using System;
using Xamarin.Essentials;
using System.IO;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using MapleSugar.Pages;

namespace MapleSugar.PageModels
{
    public class CheckListPageModel : PageModelBase
    {
        public ICommand OnEditCommand { get; set; }
        public List<WorkCheckListItem> WorkCheckListItems { get; set; }

        private int _sector;
        public int Sector
        {
            get => _sector;
            set
            {
                SetProperty(ref _sector, value);
            }
        }

        private string _treeNumber;
        public string TreeNumber
        {
            get => _treeNumber;
            set
            {
                SetProperty(ref _treeNumber, value);
            }
        }

        private string _subTreeNumber;
        public string SubTreeNumber
        {
            get => _subTreeNumber;
            set
            {
                SetProperty(ref _subTreeNumber, value);
            }
        }

        private string _treeSubLetter;
        public string TreeSubLetter
        {
            get => _treeSubLetter;
            set
            {
                SetProperty(ref _treeSubLetter, value);
            }
        }

        private string _treeLocation;
        public string TreeLocation
        {
            get => _treeLocation;
            set
            {
                SetProperty(ref _treeLocation, value);
            }
        }

        private string _treeCombineWith;
        public string TreeCombineWith
        {
            get => _treeCombineWith;
            set
            {
                SetProperty(ref _treeCombineWith, value);
            }
        }

        private bool _treeReprintTag;
        public bool TreeReprintTag
        {
            get => _treeReprintTag;
            set
            {
                SetProperty(ref _treeReprintTag, value);
            }
        }

        private bool _treeTapTube;
        public bool TreeTapTube
        {
            get => _treeTapTube;
            set
            {
                SetProperty(ref _treeTapTube, value);
            }
        }

        private double _circumference;
        public double Circumference
        {
            get => _circumference;
            set
            {
                SetProperty(ref _circumference, value);
            }
        }

        private string _comments;
        public string Comments
        {
            get => _comments;
            set
            {
                SetProperty(ref _comments, value);
            }
        }

        private double _gridX;
        public double GridX
        {
            get => _gridX;
            set
            {
                SetProperty(ref _gridX, value);
            }
        }

        private double _gridY;
        public double GridY
        {
            get => _gridY;
            set
            {
                SetProperty(ref _gridY, value);
            }
        }

        private string _container;
        public string Container
        {
            get => _container;
            set
            {
                SetProperty(ref _container, value);
            }
        }

        private double _latSec;
        public double LatSec
        {
            get => _latSec;
            set
            {
                SetProperty(ref _latSec, value);
            }
        }

        private double _lonSec;
        public double LonSec
        {
            get => _lonSec;
            set
            {
                SetProperty(ref _lonSec, value);
            }
        }

        private bool _tapped;
        public bool Tapped
        {
            get => _tapped;
            set
            {
                SetProperty(ref _tapped, value);
            }
        }

        ObservableCollection<WorkTreeLocationItem> _workTreeLocationItem;
        public ObservableCollection<WorkTreeLocationItem> WorkTreeLocationItems
        {
            get => _workTreeLocationItem;
            set => SetProperty(ref _workTreeLocationItem, value);
        }

        ButtonModel _editDataModel;

        public ButtonModel EditDataModel
        {
            get => _editDataModel;
            set => SetProperty(ref _editDataModel, value);
        }

        ButtonModel _load_Button_Clicked;

        public ButtonModel Load_Button_Clicked
        {
            get => _load_Button_Clicked;
            set => SetProperty(ref _load_Button_Clicked, value);
        }

        ButtonModel _close_App_Clicked;
        public ButtonModel Close_App_Clicked
        {
            get => _close_App_Clicked;
            set => SetProperty(ref _close_App_Clicked, value);
        }

        public ObservableCollection<Grouping<string, CheckListItem>> MyItems { get; set; } = new ObservableCollection<Grouping<string, CheckListItem>>();

        INavigation navigationService;       

       public CheckListPageModel(INavigation navigationService)
        {
             this.navigationService = navigationService;           
            WorkTreeLocationItems = new ObservableCollection<WorkTreeLocationItem>();
            Load_Button_Clicked = new ButtonModel("Load Data", LoadCheckListAction);
            // OnEditCommand = new Command(OnEditCommandAction);
            Close_App_Clicked = new ButtonModel("Close App", CloseAppAction);           
        }

        private async void LoadCheckListAction()       
        {
            try
            {               
                var file = await FilePicker.PickAsync();

                if (file != null)
                {
                   
                    var items = from Trees in CheckListService.GetSTrees(File.ReadAllText(file.FullPath))
                                orderby Trees.Sector, Trees.TreeNumber, Trees.SubTreeNumber, Trees.TreeSubLetter
                                group Trees by Trees.Sector.ToString().ToUpperInvariant() into sectorGroup
                                select new Grouping<string, CheckListItem>(sectorGroup.Key, sectorGroup);

                    foreach (var g in items)
                        MyItems.Add(g);

                    BindingContext = this;

                }
            }
            catch (Exception)
            {

            }
        }
        public void OnEditCommandAction(object SelectedObj)
        {
            CheckListItem checkListItem = SelectedObj as CheckListItem;
            navigationService.PushAsync(new TreeInfoPage(checkListItem));      
            return;
        }

        public void CloseAppAction()
        {
            System.Environment.Exit(0);
        }

    }
}
