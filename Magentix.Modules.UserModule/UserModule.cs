using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Magentix.Domain.Models.Users;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.UserModule
{
    [ModuleExport(typeof(UserModule))]
    public class UserModule : ModuleBase
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public UserModule(IRegionManager regionManager)
        {
            AddDashboardCommand<EntityCollectionViewModelBase<UserRoleViewModel, UserRole>>(Resources.UserRoleList, Resources.Users, 60);
            AddDashboardCommand<EntityCollectionViewModelBase<UserViewModel, User>>(Resources.UserList, Resources.Users, 60);
            _regionManager = regionManager;
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.RightUserRegion, typeof(LoggedInUserView));
        }
    }
}
