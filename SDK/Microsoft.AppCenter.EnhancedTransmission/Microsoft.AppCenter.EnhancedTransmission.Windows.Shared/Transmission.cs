using Microsoft.AppCenter.Channel;
using Microsoft.AppCenter.Ingestion.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AppCenter.EnhancedTransmission
{
    public partial class Transmission : AppCenterService
    {
        #region static

        private static readonly object TransmissionLock = new object();

        private static Transmission _instanceField;

        // ReSharper disable once MemberCanBePrivate.Global
        // (Used by reflection from the core).
        public static Transmission Instance
        {
            get
            {
                lock (TransmissionLock)
                {
                    return _instanceField ?? (_instanceField = new Transmission());
                }
            }
        }

        private static Task<bool> PlatformIsEnabledAsync()
        {
            lock (TransmissionLock)
            {
                return Task.FromResult(Instance.InstanceEnabled);
            }
        }

        private static Task PlatformSetEnabledAsync(bool enabled)
        {
            lock (TransmissionLock)
            {
                Instance.InstanceEnabled = enabled;
                return Task.FromResult(default(object));
            }
        }

        #endregion

        #region instance


        public override bool InstanceEnabled
        {
            get => base.InstanceEnabled;

            set
            {
                lock (_serviceLock)
                {
                    var prevValue = InstanceEnabled;
                    base.InstanceEnabled = value;
                    if (value != prevValue)
                    {
                        ApplyEnabledState(value);
                    }
                }
            }
        }

        public override string ServiceName => "Transmission";

        protected override string ChannelName => "EnhancedTransmission";

        public override void OnChannelGroupReady(IChannelGroup channelGroup, string appSecret)
        {
            lock (_serviceLock)
            {
                base.OnChannelGroupReady(channelGroup, appSecret);
                ApplyEnabledState(InstanceEnabled);
            }
        }


        private void ApplyEnabledState(bool enabled)
        {
            lock (_serviceLock)
            {
                if (enabled)
                {
                    // hook before send events delegate
                    
                }
            }

            #endregion
        }
    }
}
