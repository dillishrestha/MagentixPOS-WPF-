using System;
using System.Linq;
using Magentix.Localization.Properties;

namespace Magentix.Modules.SettingsModule.BrowserViews
{
    class MagentixPosWiki : BrowserViewModel
    {
        public MagentixPosWiki()
        {
            Header = string.Format("MagentixPOS {0}", Resources.Wiki);
            Url = "http://www.Magentixpos.com/wiki/";
        }
    }
}
