using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FullScreenKeyboardReborn
{
    /// <summary>
    /// Loads and manages language resources from JSON files
    /// </summary>
    public class LanguageResource
    {
        private readonly Dictionary<string, object> resources;
        private readonly string culture;

        /// <summary>
        /// Gets the culture code for this resource
        /// </summary>
        public string Culture => culture;

        /// <summary>
        /// Initializes a new instance of LanguageResource
        /// </summary>
        /// <param name="cultureName">Culture code (e.g., "zh-CN", "en-US")</param>
        public LanguageResource(string cultureName)
        {
            culture = cultureName;
            resources = new Dictionary<string, object>();
            LoadFromJson(cultureName);
        }

        /// <summary>
        /// Gets a localized string by key
        /// </summary>
        /// <param name="key">Resource key using dot notation (e.g., "Common.OK")</param>
        /// <returns>Localized string or the key itself if not found</returns>
        public string GetString(string key)
        {
            return GetString(key, key);
        }

        /// <summary>
        /// Gets a localized string by key with a default value
        /// </summary>
        /// <param name="key">Resource key using dot notation</param>
        /// <param name="defaultValue">Default value if key not found</param>
        /// <returns>Localized string or default value</returns>
        public string GetString(string key, string defaultValue)
        {
            if (string.IsNullOrEmpty(key))
                return defaultValue;

            try
            {
                string[] parts = key.Split('.');
                object current = resources;

                foreach (string part in parts)
                {
                    if (current is Dictionary<string, object> dict)
                    {
                        if (dict.ContainsKey(part))
                        {
                            current = dict[part];
                        }
                        else
                        {
                            return defaultValue;
                        }
                    }
                    else
                    {
                        return defaultValue;
                    }
                }

                return current?.ToString() ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Loads language resources from JSON file
        /// </summary>
        /// <param name="cultureName">Culture code</param>
        private void LoadFromJson(string cultureName)
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(Path.Combine(Path.Combine(appPath, "Resources"), "Languages"), cultureName + ".json");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("[LanguageResource] Warning: Language file not found: " + filePath);
                    return;
                }

                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);

                // Convert JObject to nested dictionaries
                ConvertJsonToDictionary(jsonObject, resources);

                Console.WriteLine("[LanguageResource] Loaded language: " + cultureName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LanguageResource] Error loading language file: " + ex.Message);
            }
        }

        /// <summary>
        /// Recursively converts JObject to nested dictionaries
        /// </summary>
        private void ConvertJsonToDictionary(JObject jObject, Dictionary<string, object> dict)
        {
            foreach (var property in jObject.Properties())
            {
                if (property.Value is JObject nestedObject)
                {
                    var nestedDict = new Dictionary<string, object>();
                    ConvertJsonToDictionary(nestedObject, nestedDict);
                    dict[property.Name] = nestedDict;
                }
                else if (property.Value is JValue jValue)
                {
                    dict[property.Name] = jValue.Value?.ToString() ?? string.Empty;
                }
            }
        }
    }
}
