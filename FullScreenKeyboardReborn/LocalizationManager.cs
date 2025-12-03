using System;

namespace FullScreenKeyboardReborn
{
    /// <summary>
    /// Singleton manager for application localization
    /// Manages language resources and provides global access to localized strings
    /// </summary>
    public class LocalizationManager
    {
        private static LocalizationManager instance;
        private static readonly object lockObject = new object();

        private LanguageResource currentLanguage;
        private string currentCulture;

        /// <summary>
        /// Event fired when the language changes
        /// </summary>
        public event EventHandler LanguageChanged;

        /// <summary>
        /// Gets the singleton instance
        /// </summary>
        public static LocalizationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new LocalizationManager();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the current culture code
        /// </summary>
        public string CurrentCulture
        {
            get { return currentCulture; }
            private set { currentCulture = value; }
        }

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private LocalizationManager()
        {
            // Default to Chinese
            currentCulture = "zh-CN";
            currentLanguage = new LanguageResource(currentCulture);
        }

        /// <summary>
        /// Initializes the localization manager with the specified culture
        /// </summary>
        /// <param name="culture">Culture code to load</param>
        public void Initialize(string culture)
        {
            if (string.IsNullOrEmpty(culture))
            {
                culture = "zh-CN";
            }

            currentCulture = culture;
            currentLanguage = new LanguageResource(culture);
            Console.WriteLine("[LocalizationManager] Initialized with culture: " + culture);
        }

        /// <summary>
        /// Changes the current language
        /// </summary>
        /// <param name="culture">Culture code (e.g., "zh-CN", "en-US")</param>
        /// <returns>True if language changed successfully</returns>
        public bool ChangeLanguage(string culture)
        {
            if (string.IsNullOrEmpty(culture))
            {
                Console.WriteLine("[LocalizationManager] Invalid culture code");
                return false;
            }

            if (culture == currentCulture)
            {
                Console.WriteLine("[LocalizationManager] Language already set to: " + culture);
                return true;
            }

            try
            {
                // Try to load the new language
                var newLanguage = new LanguageResource(culture);
                
                currentCulture = culture;
                currentLanguage = newLanguage;

                // Save to settings
                Settings.CurrentCulture = culture;
                Settings.Save();

                // Notify all subscribers
                OnLanguageChanged();

                Console.WriteLine("[LocalizationManager] Language changed to: " + culture);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LocalizationManager] Error changing language: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets a localized string by key
        /// </summary>
        /// <param name="key">Resource key using dot notation (e.g., "Common.OK")</param>
        /// <returns>Localized string or the key itself if not found</returns>
        public string GetString(string key)
        {
            if (currentLanguage == null)
            {
                return key;
            }
            return currentLanguage.GetString(key);
        }

        /// <summary>
        /// Gets a localized string by key with a default value
        /// </summary>
        /// <param name="key">Resource key using dot notation</param>
        /// <param name="defaultValue">Default value if key not found</param>
        /// <returns>Localized string or default value</returns>
        public string GetString(string key, string defaultValue)
        {
            if (currentLanguage == null)
            {
                return defaultValue;
            }
            return currentLanguage.GetString(key, defaultValue);
        }

        /// <summary>
        /// Gets localized enum display name
        /// </summary>
        /// <param name="enumValue">Enum value</param>
        /// <returns>Localized enum name</returns>
        public string GetEnumString(Enum enumValue)
        {
            if (enumValue == null)
                return string.Empty;

            string enumType = enumValue.GetType().Name;
            string enumName = enumValue.ToString();
            string key = enumType + "." + enumName;

            return GetString(key, enumName);
        }

        /// <summary>
        /// Raises the LanguageChanged event
        /// </summary>
        protected virtual void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
