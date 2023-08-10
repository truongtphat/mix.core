

using Microsoft.Extensions.Configuration;

namespace Mix.Shared.Services
{
    public class PortalConfigService : JsonConfigurationServiceBase
    {
       

        public PortalConfigService(IConfiguration configuration)
            : base(configuration, MixAppSettingsSection.Portal, MixAppSettingsFilePaths.Portal)
        {
        }
    }
}
