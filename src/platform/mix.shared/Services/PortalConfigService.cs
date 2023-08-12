

using Microsoft.Extensions.Configuration;

namespace Mix.Shared.Services
{
    public class PortalConfigService : JsonConfigurationServiceBase
    {
       

        public PortalConfigService() : base(MixAppSettingsSection.Portal, MixAppSettingsFilePaths.Portal)
        {
        }
    }
}
