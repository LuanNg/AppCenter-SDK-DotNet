using System.Threading.Tasks;

namespace Microsoft.Azure.Mobile.Push
{
    [System.Obsolete("Mobile Center classes are deprecated. Please use the new App Center ones. More information about migration is available at https://aka.ms/Yp48u5")]
    public partial class Push
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
