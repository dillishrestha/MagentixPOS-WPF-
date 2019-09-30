using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Magentix.Domain.Models;
using Magentix.Domain.Models.Entities;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.EntityModule
{
    [ModuleExport(typeof(EntityModule))]
    class EntityModule : ModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IApplicationStateSetter _applicationStateSetter;
        private readonly EntityEditorView _entityEditorView;
        private readonly EntitySwitcherView _entitySwitcherView;

        [ImportingConstructor]
        public EntityModule(IRegionManager regionManager, IUserService userService, IApplicationStateSetter applicationStateSetter,
            EntitySwitcherView entitySwitcherView, EntityEditorView entityEditorView)
        {
            _entitySwitcherView = entitySwitcherView;
            _entityEditorView = entityEditorView;
            _regionManager = regionManager;
            _applicationStateSetter = applicationStateSetter;

            AddDashboardCommand<EntityCollectionViewModelBase<EntityTypeViewModel, EntityType>>(Resources.EntityType.ToPlural(), Resources.Entities, 40);
            AddDashboardCommand<EntityCollectionViewModelBase<EntityViewModel, Entity>>(Resources.Entity.ToPlural(), Resources.Entities, 40);
            AddDashboardCommand<EntityCollectionViewModelBase<EntityScreenViewModel, EntityScreen>>(Resources.EntityScreen.ToPlural(), Resources.Entities, 41);
            AddDashboardCommand<BatchEntityEditorViewModel>(Resources.BatchEntityEditor, Resources.Entities, 40);
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(EntitySwitcherView));
            _regionManager.RegisterViewWithRegion(RegionNames.EntityScreenRegion, typeof(EntitySelectorView));
            _regionManager.RegisterViewWithRegion(RegionNames.EntityScreenRegion, typeof(EntitySearchView));
            _regionManager.RegisterViewWithRegion(RegionNames.EntityScreenRegion, typeof(EntityEditorView));
            _regionManager.RegisterViewWithRegion(RegionNames.EntityScreenRegion, typeof(EntityDashboardView));

            EventServiceFactory.EventService.GetEvent<GenericEvent<OperationRequest<Entity>>>().Subscribe(x =>
            {
                if (x.Topic == EventTopicNames.SelectEntity) ActivateEntitySwitcher();
                if (x.Topic == EventTopicNames.EditEntityDetails) ActivateEntityEditor();
            });

            EventServiceFactory.EventService.GetEvent<GenericEvent<OperationRequest<AccountData>>>().Subscribe(x =>
            {
                if (x.Topic == EventTopicNames.SelectEntity) ActivateEntitySwitcher();
            });
        }

        private void ActivateEntityEditor()
        {
            _applicationStateSetter.SetCurrentApplicationScreen(AppScreens.EntityView);
            _regionManager.ActivateRegion(RegionNames.EntityScreenRegion, _entityEditorView);
        }

        private void ActivateEntitySwitcher()
        {
            _applicationStateSetter.SetCurrentApplicationScreen(AppScreens.EntityView);
            _regionManager.ActivateRegion(RegionNames.MainRegion, _entitySwitcherView);
        }
    }
}
