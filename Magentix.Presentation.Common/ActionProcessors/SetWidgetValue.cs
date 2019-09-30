using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.Widgets;
using Magentix.Presentation.Services.Common;
using Magentix.Services.Common;

namespace Magentix.Presentation.Common.ActionProcessors
{
    [Export(typeof(IActionType))]
    class SetWidgetValue : ActionType
    {
        public override void Process(ActionData actionData)
        {
            var widgetName = actionData.GetAsString("WidgetName");
            var value = actionData.GetAsString("Value") ?? "";
            if (!string.IsNullOrEmpty(widgetName))
            {
                var data = new WidgetEventData { WidgetName = widgetName, Value = value };
                data.PublishEvent(EventTopicNames.SetWidgetValue);
            }
        }

        protected override object GetDefaultData()
        {
            return new { WidgetName = "", Value = "" };
        }

        protected override string GetActionName()
        {
            return Resources.SetWidgetValue;
        }

        protected override string GetActionKey()
        {
            return ActionNames.SetWidgetValue;
        }
    }
}
