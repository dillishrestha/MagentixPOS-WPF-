using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.AutomationModule
{
    public class ParameterValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ValueTemplate { get; set; }
        public DataTemplate PasswordTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var pv = item as ParameterValue;
            if (pv != null)
            {
                if (pv.Name.Contains("Password")) return PasswordTemplate;
                if (pv.Values.Any()) return ValueTemplate;
            }
            return TextTemplate;
        }
    }
}