

using Microsoft.Extensions.Configuration;

namespace Mix.Shared.Services
{
    public class SmtpConfigService : JsonConfigurationServiceBase
    {
        public SmtpConfigService() : base(MixAppSettingsSection.Smtp, MixAppSettingsFilePaths.Smtp)
        {
        }
    }
}
