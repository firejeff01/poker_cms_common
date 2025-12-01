namespace Poker.CMS.Common.Localization
{
    /// <summary>
    /// JsonLocalization
    /// </summary>
    public class JsonLocalization
    {
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// The localized value
        /// </summary>
        public Dictionary<string, string> LocalizedValue = new Dictionary<string, string>();
    }
}