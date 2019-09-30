using System.ComponentModel.Composition;
using System.IO;
using Magentix.Infrastructure.Settings;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;

namespace Magentix.Modules.LoginModule
{
    [Export]
    public class LoginViewModel
    {
        private readonly IUserService _userService;

        [ImportingConstructor]
        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public string LogoPath
        {
            get
            {
                if (File.Exists(LocalSettings.LogoPath))
                    return LocalSettings.LogoPath;
                if (File.Exists(LocalSettings.DocumentPath + "\\Images\\logo.png"))
                    return LocalSettings.DocumentPath + "\\Images\\logo.png";
                if (File.Exists(LocalSettings.AppPath + "\\Images\\logo.png"))
                    return LocalSettings.AppPath + "\\Images\\logo.png";
                return LocalSettings.AppPath + "\\Images\\empty.png";
            }
            set { LocalSettings.LogoPath = value; }
        }

        public string AppLabel { get { return "Magentix POS " + LocalSettings.AppVersion + " - " + GetDatabaseLabel(); } }
        public string AdminPasswordHint { get { return GetAdminPasswordHint(); } }
        public string SqlHint { get { return GetSqlHint(); } }

        private string GetSqlHint()
        {
            return !string.IsNullOrEmpty(GetAdminPasswordHint()) ? Resources.SqlHint : "";
        }

        private static string GetDatabaseLabel()
        {
            return LocalSettings.DatabaseLabel;
        }

        public string GetAdminPasswordHint()
        {
            if ((GetDatabaseLabel() == "TX" || GetDatabaseLabel() == "CE") && _userService.IsDefaultUserConfigured)
            {
                return Resources.AdminPasswordHint;
            }

            return "";
        }
    }
}
