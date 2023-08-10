

using Microsoft.Extensions.Configuration;

namespace Mix.Shared.Services
{
    public class SmtpConfigService : JsonConfigurationServiceBase
    {
        public SmtpConfigService(IConfiguration configuration)
            : base(configuration, MixAppSettingsSection.Smtp, MixAppSettingsFilePaths.Smtp)
        {
        }
    }
}
