

using Microsoft.Extensions.Configuration;

namespace Mix.Shared.Services
{
    public class IPSecurityConfigService : JsonConfigurationServiceBase
    {
        public IPSecurityConfigService()
            : base(MixAppSettingsSection.IPSecurity, MixAppSettingsFilePaths.IPSecurity)
        {
        }
    }
}
