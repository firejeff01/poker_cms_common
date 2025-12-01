using Microsoft.Extensions.Localization;

namespace Poker.CMS.Common.Localization
{
    /// <summary>
    /// JsonStringLocalizerFactory
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Localization.IStringLocalizerFactory" />
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        /// <summary>
        /// Creates an <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" /> using the <see cref="T:System.Reflection.Assembly" /> and
        /// <see cref="P:System.Type.FullName" /> of the specified <see cref="T:System.Type" />.
        /// </summary>
        /// <param name="resourceSource">The <see cref="T:System.Type" />.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
        /// </returns>
        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer();
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
        /// </summary>
        /// <param name="baseName">The base name of the resource to load strings from.</param>
        /// <param name="location">The location to load resources from.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
        /// </returns>
        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer();
        }
    }
}