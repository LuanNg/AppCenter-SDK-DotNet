using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Mobile.Push
{
    /// <summary>
    /// Push feature.
    /// </summary>
    [System.Obsolete("Mobile Center classes are deprecated. Please use the new App Center ones. More information about migration is available at https://aka.ms/Yp48u5")]
    public partial class Push
    {
        /// <summary>
        /// Check whether the Push service is enabled or not.
        /// </summary>
        /// <returns>A task with result being true if enabled, false if disabled.</returns>
        public static Task<bool> IsEnabledAsync()
        {
            return PlatformIsEnabledAsync();
        }

		/// <summary>
		/// Enable or disable the Push service.
		/// </summary>
		/// <returns>A task to monitor the operation.</returns>
		public static Task SetEnabledAsync(bool enabled)
        {
            return PlatformSetEnabledAsync(enabled);
        }

        /// <summary>
        /// Occurs when the application receives a push notification.
        /// </summary>
        public static event EventHandler<PushNotificationReceivedEventArgs> PushNotificationReceived;
    }
}
