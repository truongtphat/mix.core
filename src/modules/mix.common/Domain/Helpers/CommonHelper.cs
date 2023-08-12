using Mix.Common.Models;
using Mix.Service.Models;
using Mix.Shared.Models.Configurations;
using Mix.Shared.Services;
using System.Configuration;

namespace Mix.Common.Domain.Helpers
{
    public sealed class CommonHelper
    {
        public static GlobalSettings GetAppSettings(
            IConfiguration configuration,
            MixAuthenticationConfigurations authConfigurations, MixTenantSystemModel currentTenant)
        {
            //var cultures = _cultureService.Cultures;
            //var culture = _cultureService.LoadCulture(lang);
            // Get Settings
            return new()
            {
                Domain = currentTenant?.Configurations.Domain,
                DefaultCulture = currentTenant?.Configurations.DefaultCulture,
                IsEncryptApi = currentTenant?.Configurations.IsEncryptApi ?? false,
                PortalThemeSettings = LoadAppSettings(configuration, MixAppSettingsFilePaths.Portal, MixAppSettingsSection.Portal),
                LastUpdateConfiguration = currentTenant?.Configurations.LastUpdateConfiguration,
                ApiEncryptKey = GlobalConfigService.Instance.AppSettings.ApiEncryptKey,
                PageTypes = Enum.GetNames(typeof(MixPageType)),
                ModuleTypes = Enum.GetNames(typeof(MixModuleType)),
                MixDatabaseTypes = Enum.GetNames(typeof(MixDatabaseType)),
                DataTypes = Enum.GetNames(typeof(MixDataType)),
                Statuses = Enum.GetNames(typeof(MixContentStatus)),
                RSAKeys = RSAEncryptionHelper.GenerateKeys(),
                ExternalLoginProviders = new JObject()
                {
                    new JProperty("Facebook", authConfigurations.Facebook?.AppId),
                    new JProperty("Google", authConfigurations.Google?.AppId),
                    new JProperty("Twitter", authConfigurations.Twitter?.AppId),
                    new JProperty("Microsoft", authConfigurations.Microsoft?.AppId),
                }
            };
        }

        private static JObject LoadAppSettings(IConfiguration configuration, string filePath, string section)
        {
            var settings = MixFileHelper.GetFileByFullName($"{filePath}{MixFileExtensions.Json}", true);
            string content = string.IsNullOrWhiteSpace(settings.Content) ? "{}" : settings.Content;
            return JObject.Parse(content).Value<JObject>(section);
        }
    }
}
