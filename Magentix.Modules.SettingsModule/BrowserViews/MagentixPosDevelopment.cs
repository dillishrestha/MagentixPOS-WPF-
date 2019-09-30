using System;
using System.Linq;
using Magentix.Localization.Properties;

namespace Magentix.Modules.SettingsModule.BrowserViews
{
    class MagentixPosDevelopment : BrowserViewModel
    {
        public MagentixPosDevelopment()
        {
            Header = string.Format("MagentixPOS {0}", Resources.Development);
            Url = "https://github.com/emreeren/MagentixPOS-3";
        }
    }
}
