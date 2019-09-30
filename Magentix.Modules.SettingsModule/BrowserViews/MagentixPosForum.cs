using System;
using System.Linq;
using Magentix.Localization.Properties;

namespace Magentix.Modules.SettingsModule.BrowserViews
{
    class MagentixPosForum : BrowserViewModel
    {
        public MagentixPosForum()
        {
            Header = string.Format("MagentixPOS {0}", Resources.Forum);
            Url = "http://forum2.Magentixpos.com";
        }
    }
}
