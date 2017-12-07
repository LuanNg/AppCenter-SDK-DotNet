using System.Threading.Tasks;

namespace Microsoft.AppCenter.EnhancedTransmission
{
    public partial class Transmission
    {
        static Task<bool> PlatformIsEnabledAsync()
        {
            return Task.FromResult(false);
        }

        static Task PlatformSetEnabledAsync(bool enabled)
        {
            return Task.FromResult(default(object));
        }
    }
}
