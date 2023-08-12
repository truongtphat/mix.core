using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Mix.Shared.Services
{
    public abstract class AppSettingServiceBase<T>
    {
        private string _filePath;
        protected string _sectionName;
        public T AppSettings { get; set; }
        protected string FilePath { get => _filePath; set => _filePath = value; }

        protected readonly FileSystemWatcher watcher = new();
        protected readonly IConfiguration _configuration;
        protected DateTime LastModified { get; private set; }
        protected DateTime LastSaved { get; private set; }
        public AppSettingServiceBase(IConfiguration configuration, string section, string filePath)
        {
            _configuration = configuration;
            _sectionName = section;
            FilePath = filePath;
            LoadAppSettings();
            WatchFile();
        }

        private void WatchFile()
        {
            watcher.Path = FilePath[..FilePath.LastIndexOf('/')];
            watcher.Filter = "";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (LastSaved > LastModified)
            {
                Thread.Sleep(500);
                LoadAppSettings();
            }
        }

        public bool SaveSettings()
        {
            var settings = MixFileHelper.GetFile(FilePath, MixFileExtensions.Json, string.Empty, true, "{}");
            if (settings != null)
            {
                settings.Content = new JObject(new JProperty(_sectionName, JObject.FromObject(AppSettings))).ToString();
                LastSaved = DateTime.UtcNow;
                return MixFileHelper.SaveFile(settings);
            }
            else
            {
                return false;
            }
        }

        protected virtual void LoadAppSettings()
        {
            try
            {
                var settings = _configuration.GetSection(_sectionName);
                AppSettings = (T)Activator.CreateInstance(typeof(T));
                settings.Bind(AppSettings);
                LastModified = DateTime.UtcNow;
                LastSaved = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                throw new MixException($"Cannot load config section {_sectionName}: {ex.Message}");
            }
        }
    }
}
