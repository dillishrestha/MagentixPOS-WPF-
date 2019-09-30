using System;
using System.Linq;
using Magentix.Localization.Properties;

namespace Magentix.Modules.SettingsModule.BrowserViews
{
    class MagentixPosWebsite : BrowserViewModel
    {
        public MagentixPosWebsite()
        {
            Header = string.Format("MagentixPOS {0}", Resources.Website);
            Url = "http://www.Magentixpos.com";
        }
    }
}
