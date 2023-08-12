using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Mix.Shared.Services
{
    public class JsonConfigurationServiceBase
    {
        public JObject AppSettings { get; set; }
        protected string FilePath { get; set; }
        protected string Section { get; set; }
        protected DateTime LastModified { get; private set; }
        protected DateTime LastSaved { get; private set; }

        protected readonly FileSystemWatcher watcher = new();
        public JsonConfigurationServiceBase(string section, string filePath)
        {
            Section = section;
            FilePath = filePath;
            LoadAppSettings();
            LastModified = DateTime.UtcNow;
            LastSaved = DateTime.UtcNow;
            WatchFile();
        }

        public T GetConfig<T>(string name, T defaultValue = default)
        {
            var result = AppSettings[name];
            return result != null ? result.Value<T>() : defaultValue;
        }

        public T GetConfig<T>(string culture, string name, T defaultValue = default)
        {
            JToken result = null;
            if (!string.IsNullOrEmpty(culture) && AppSettings[culture] != null)
            {
                result = AppSettings[culture][name];
            }
            return result != null ? result.Value<T>() : defaultValue;
        }

        public T GetEnumConfig<T>(string name)
        {
            Enum.TryParse(typeof(T), AppSettings[name]?.Value<string>(), true, out object result);
            return result != null ? (T)result : default;
        }

        public void SetConfig<T>(string name, T value)
        {
            AppSettings[name] = object.Equals(value, default(T)) ? JToken.FromObject(value) : null;
            SaveSettings();
        }

        public void SetConfig<T>(string culture, string name, T value)
        {
            AppSettings[culture][name] = value.ToString();
            SaveSettings();
        }

        public bool SaveSettings()
        {
            var settings = MixFileHelper.GetFileByFullName($"{FilePath}{MixFileExtensions.Json}", true);
            if (settings != null)
            {
                settings.Content = (new JObject(new JProperty(Section, AppSettings))).ToString();
                LastSaved = DateTime.UtcNow;
                return MixFileHelper.SaveFile(settings);
            }
            else
            {
                return false;
            }
        }

        protected void WatchFile()
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

        protected virtual void LoadAppSettings()
        {
            var settings = MixFileHelper.GetFileByFullName($"{FilePath}{MixFileExtensions.Json}", true);
            string content = string.IsNullOrWhiteSpace(settings.Content) ? "{}" : settings.Content;
            AppSettings = JObject.Parse(content).Value<JObject>(Section) ?? new();
        }
    }
}
