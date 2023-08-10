using Microsoft.AspNetCore.Mvc;
using Mix.Heart.Exceptions;
using Mix.Identity.Constants;
using Mix.Lib.Interfaces;
using Mix.Lib.Services;
using Mix.Queue.Interfaces;
using Mix.Queue.Models;
using Mix.Service.Models;
using MySqlX.XDevAPI.Common;

namespace Mix.Common.Controllers
{
    // TODO: NEED TO ENHANCE SECURITY FOR THESE APIs
    [Route("api/v2/rest/settings")]
    [ApiController]
    [MixAuthorize(roles: MixRoles.Owner)]
    public class SettingApiController : MixTenantApiControllerBase
    {
        private ConfigurationServiceBase<JObject> _settingService;
        public SettingApiController(
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            MixCacheService cacheService,
            TranslatorService translator,
            MixIdentityService mixIdentityService,
            IQueueService<MessageQueueModel> queueService,
            IMixTenantService mixTenantService)
            : base(httpContextAccessor, configuration, 
                  cacheService, translator, mixIdentityService, queueService, mixTenantService)
        {
        }

        #region Routes

        [HttpGet]
        [Route("get-tenant-settings")]
        public ActionResult<JObject> GetTenantSettings()
        {
            try
            {
                TenantConfigService service = new(CurrentTenant.SystemName);
                if (service != null)
                {
                    return Ok(service.AppSettings);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new MixException(MixErrorStatus.NotFound, ex);
            }
        }

        [HttpPost]
        [Route("save-tenant-settings")]
        public ActionResult<JObject> SaveTenantSettings(TenantConfigurationModel appSettings)
        {
            try
            {
                TenantConfigService service = new(CurrentTenant.SystemName)
                {
                    AppSettings = appSettings
                };

                service.SaveSettings();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new MixException(MixErrorStatus.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("{settingType}")]
        public ActionResult<JObject> LoadData(MixAppConfigEnums settingType)
        {
            try
            {
                string filePath = GetSettingFilePath(settingType);
                if (!string.IsNullOrEmpty(filePath))
                {
                    _settingService = new(filePath);
                    return Ok(_settingService.AppSettings);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new MixException(MixErrorStatus.NotFound, ex);
            }
        }

        [HttpPost]
        [Route("{settingType}")]
        public ActionResult<JObject> SaveData(MixAppConfigEnums settingType, JObject appSettings)
        {
            try
            {
                string filePath = GetSettingFilePath(settingType);
                if (!string.IsNullOrEmpty(filePath))
                {
                    _settingService = new(filePath);
                    _settingService.AppSettings = appSettings;
                    _settingService.SaveSettings();
                    return Ok(_settingService.AppSettings);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new MixException(MixErrorStatus.NotFound, ex);
            }
        }



        #endregion

        #region Helpers

        private string GetSettingFilePath(MixAppConfigEnums settingType)
        {
            return settingType switch
            {
                MixAppConfigEnums.Portal => MixAppSettingsFilePaths.Portal,
                MixAppConfigEnums.Authentication => MixAppSettingsFilePaths.Authentication,
                MixAppConfigEnums.Quartz => MixAppSettingsFilePaths.Quartz,
                MixAppConfigEnums.IPSecurity => MixAppSettingsFilePaths.IPSecurity,
                MixAppConfigEnums.MixHeart => MixAppSettingsFilePaths.MixHeart,
                MixAppConfigEnums.Smtp => MixAppSettingsFilePaths.Smtp,
                MixAppConfigEnums.Endpoint => MixAppSettingsFilePaths.Endpoint,
                MixAppConfigEnums.Global => MixAppSettingsFilePaths.Global,
                MixAppConfigEnums.Azure => MixAppSettingsFilePaths.Azure,
                MixAppConfigEnums.Ocelot => MixAppSettingsFilePaths.Ocelot,
                MixAppConfigEnums.Queue => MixAppSettingsFilePaths.Queue,
                MixAppConfigEnums.Storage => MixAppSettingsFilePaths.Storage,
                MixAppConfigEnums.Payments => MixAppSettingsFilePaths.Payments,
                MixAppConfigEnums.Kiotviet => MixAppSettingsFilePaths.Kiotviet,
                MixAppConfigEnums.Log => MixAppSettingsFilePaths.Log,
                MixAppConfigEnums.RateLimit => MixAppSettingsFilePaths.RateLimit,
                MixAppConfigEnums.GoogleFirebase => MixAppSettingsFilePaths.GoogleFirebase,
                MixAppConfigEnums.GoogleCredential => MixAppSettingsFilePaths.GoogleCredential,
                _ => string.Empty
            };
        }

        #endregion

    }
}
