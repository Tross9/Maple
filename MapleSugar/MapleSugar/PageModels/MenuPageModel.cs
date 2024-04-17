using MapleSugar.PageModels.Base;
using System.Threading.Tasks;

namespace MapleSugar.PageModels
{
    public class MenuPageModel : PageModelBase
    { 
        /// <summary>
        /// 
        /// </summary>
        private CheckListPageModel _checklistPM;

        public CheckListPageModel CheckListPageModel
        {
            get => _checklistPM;
            set => SetProperty(ref _checklistPM, value);
        }
        /// <summary>
        /// 
        /// </summary>
        private CollectionPageModel _collectionPM;

        public CollectionPageModel CollectionPageModel
        {
            get => _collectionPM;
            set => SetProperty(ref _collectionPM, value);
        }
                
        /// <summary>
        /// 
        /// </summary>
        private TreeInfoPageModel _treeinfoPM;

        public TreeInfoPageModel TreeInfoPageModel
        {
            get => _treeinfoPM;
            set => SetProperty(ref _treeinfoPM, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checklistPM"></param>
        /// <param name="collectionPM"></param>
        /// <param name="treeinfoPM"></param>
        public MenuPageModel(
            
            CollectionPageModel collectionPM,           
            TreeInfoPageModel treeinfoPM,
            CheckListPageModel checklistPM)
        {
            CollectionPageModel = collectionPM;
            TreeInfoPageModel = treeinfoPM;
            CheckListPageModel = checklistPM;
        }
        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                
                TreeInfoPageModel.InitializeAsync(null),
                CollectionPageModel.InitializeAsync(null),
                CheckListPageModel.InitializeAsync(null));
        }
    }
}
