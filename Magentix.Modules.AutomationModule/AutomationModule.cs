using System.ComponentModel.Composition;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Magentix.Domain.Models.Automation;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.AutomationModule
{
    [ModuleExport(typeof(AutomationModule))]
    class AutomationModule : ModuleBase
    {
        private readonly IAutomationService _automationService;
        private readonly IApplicationState _applicationState;

        [ImportingConstructor]
        public AutomationModule(IAutomationService automationService, IApplicationState applicationState)
        {
            _automationService = automationService;
            _applicationState = applicationState;

            AddDashboardCommand<EntityCollectionViewModelBase<RuleActionViewModel, AppAction>>(Resources.RuleActions, Resources.Automation, 55);
            AddDashboardCommand<EntityCollectionViewModelBase<RuleViewModel, AppRule>>(Resources.Rules, Resources.Automation, 55);
            AddDashboardCommand<TriggerListViewModel>(Resources.Trigger.ToPlural(), Resources.Automation, 55);
            AddDashboardCommand<EntityCollectionViewModelBase<AutomationCommandViewModel, AutomationCommand>>(Resources.AutomationCommand.ToPlural(), Resources.Automation, 55);
            AddDashboardCommand<EntityCollectionViewModelBase<ScriptViewModel, Script>>(Resources.Script.ToPlural(), Resources.Automation, 55);

            HighlightingManager.Instance.RegisterHighlighting("MagentixDSL", null, () => LoadHighlightingDefinition("MagentixDSL.xshd"));

        }

        protected override void OnInitialization()
        {
            base.OnInitialization();
            _automationService.Register();

            EventServiceFactory.EventService.GetEvent<GenericEvent<ActionData>>().Subscribe(x => _automationService.ProcessAction(x.Value.Action.ActionType, x.Value));
            EventServiceFactory.EventService.GetEvent<GenericEvent<Message>>().Subscribe(x =>
            {
                if (x.Topic == EventTopicNames.MessageReceivedEvent && x.Value.Command == "ActionMessage")
                {
                    _applicationState.NotifyEvent(RuleEventNames.MessageReceived, new { Command = x.Value.Data });
                }
            });
        }

        public static IHighlightingDefinition LoadHighlightingDefinition(string resourceName)
        {
            var type = typeof(AutomationModule);
            var fullName = type.Namespace + "." + resourceName;
            using (var stream = type.Assembly.GetManifestResourceStream(fullName))
            using (var reader = new XmlTextReader(stream))
                return HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }
    }
}
