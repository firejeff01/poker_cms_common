using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace Poker.CMS.Common.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly Dictionary<string, Dictionary<string, string>> _localizations = new();

        public JsonStringLocalizer()
        {
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),     // Common Nuget 專案（嵌入資源）
                Assembly.GetEntryAssembly(),         // 執行專案（如 Main.Api）
                Assembly.GetCallingAssembly()        // 呼叫者專案（是 Shared）
            }.Where(a => a != null).Distinct().ToList();

            foreach (var assembly in assembliesToScan)
                LoadFromEmbeddedResources(assembly!);

            LoadFromPhysicalFiles(Path.Combine(AppContext.BaseDirectory, "Resources"));
        }

        private void LoadFromEmbeddedResources(Assembly assembly)
        {
            var resourceNames = assembly.GetManifestResourceNames();

            foreach (var resourceName in resourceNames)
            {
                if (!resourceName.Contains("Resources.text.") || !resourceName.EndsWith(".json"))
                    continue;

                // e.g., Poker.CMS.Common.Resources.text.zh-TW.common.json
                var parts = resourceName.Split('.');
                if (parts.Length < 6) continue;

                string culture = parts[5].Replace('_', '-'); // 取代 "_" => "-", 如 de_DE → de-DE;
                string fileName = $"{parts[6]}.{parts[7]}";

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null) continue;

                using var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (dict != null)
                    MergeLocalization(culture, fileName, dict, overrideExisting: false);
            }
        }

        private void LoadFromPhysicalFiles(string basePath)
        {
            if (!Directory.Exists(basePath)) return;

            foreach (var dir in Directory.GetDirectories(basePath))
            {
                string folder = Path.GetFileName(dir.TrimEnd(Path.DirectorySeparatorChar));
                string culture = ExtractCultureFromFolder(folder);
                if (string.IsNullOrEmpty(culture)) continue;

                foreach (var file in Directory.GetFiles(dir, "*.json"))
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    var json = File.ReadAllText(file);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                    if (dict != null)
                        MergeLocalization(culture, fileName, dict, overrideExisting: true);
                }
            }
        }

        private void MergeLocalization(string culture, string fileName, Dictionary<string, string> dict, bool overrideExisting)
        {
            if (!_localizations.ContainsKey(culture))
                _localizations[culture] = new Dictionary<string, string>();

            foreach (var kv in dict)
            {
                var fullKey = $"{fileName}.{kv.Key}";
                if (overrideExisting || !_localizations[culture].ContainsKey(fullKey))
                    _localizations[culture][fullKey] = kv.Value;

                if (fileName == "common" && (overrideExisting || !_localizations[culture].ContainsKey(kv.Key)))
                    _localizations[culture][kv.Key] = kv.Value;
            }
        }

        private string? ExtractCultureFromFolder(string folderName)
        {
            return folderName.StartsWith("text.") && folderName.Length > 5
                ? folderName.Substring(5)
                : null;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            if (_localizations.TryGetValue(culture, out var dict))
            {
                return dict.Select(kv => new LocalizedString(kv.Key, kv.Value, false));
            }

            return Enumerable.Empty<LocalizedString>();
        }

        public IStringLocalizer WithCulture(CultureInfo culture) => this;

        private string? GetString(string name)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            return _localizations.TryGetValue(culture, out var dict)
                && dict.TryGetValue(name, out var value)
                ? value
                : null;
        }
    }
}
