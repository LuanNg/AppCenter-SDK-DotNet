using System.Threading.Tasks;

namespace Microsoft.AppCenter.EnhancedTransmission
{
    /// <summary>
    /// Transmission feature.
    /// </summary>
    public partial class Transmission
    {
        /// <summary>
        /// Check whether the Transmission service is enabled or not.
        /// </summary>
        /// <returns>A task with result being true if enabled, false if disabled.</returns>
        public static Task<bool> IsEnabledAsync()
        {
            return PlatformIsEnabledAsync();
        }

        /// <summary>
        /// Enable or disable the Transmission service.
        /// </summary>
        /// <returns>A task to monitor the operation.</returns>
        public static Task SetEnabledAsync(bool enabled)
        {
            return PlatformSetEnabledAsync(enabled);
        }

    }
}
