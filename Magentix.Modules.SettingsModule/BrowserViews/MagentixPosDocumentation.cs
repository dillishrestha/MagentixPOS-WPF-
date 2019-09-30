using System;
using System.Linq;
using Magentix.Localization.Properties;

namespace Magentix.Modules.SettingsModule.BrowserViews
{
    class MagentixPosDocumentation : BrowserViewModel
    {
        public MagentixPosDocumentation()
        {
            Header = string.Format("MagentixPOS {0}", Resources.Documentation);
            Url = "http://www.Magentixpos.com/en/content/Magentixpos-documentation";
        }
    }
}
