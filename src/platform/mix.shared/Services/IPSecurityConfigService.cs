

using Microsoft.Extensions.Configuration;

namespace Mix.Shared.Services
{
    public class IPSecurityConfigService : JsonConfigurationServiceBase
    {
        public IPSecurityConfigService(IConfiguration configuration)
            : base(configuration, MixAppSettingsSection.IPSecurity, MixAppSettingsFilePaths.IPSecurity)
        {
        }
    }
}
