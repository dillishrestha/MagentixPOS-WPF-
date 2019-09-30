using Magentix.Infrastructure.Settings;

namespace Magentix.Presentation.Services.Common
{
    public static class AppServices
    {

        public static bool CanStartApplication()
        {
            return LocalSettings.CurrentDbVersion <= 0 || LocalSettings.CurrentDbVersion == LocalSettings.DbVersion;
        }


    }
}
