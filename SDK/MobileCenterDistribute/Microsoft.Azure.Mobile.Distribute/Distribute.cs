using System.Threading.Tasks;

namespace Microsoft.Azure.Mobile.Distribute
{
    [System.Obsolete("Mobile Center classes are deprecated because the product name is changed to App Center. Please update your application to use the latest App Center Nugets. More information about the SDK migration is available at https://aka.ms/Yp48u5")]
    public static partial class Distribute
    {
        static Task<bool> PlatformIsEnabledAsync()
        {
            return Task.FromResult(false);
        }

        static Task PlatformSetEnabledAsync(bool enabled)
        {
            return Task.FromResult(default(object));
        }

        static void PlatformSetInstallUrl(string installUrl)
        {
        }

        static void PlatformSetApiUrl(string apiUrl)
        {
        }

        static void SetReleaseAvailableCallback(ReleaseAvailableCallback releaseAvailableCallback)
        {
        }

        static void HandleUpdateAction(UpdateAction updateAction)
        {
        }
    }
}
