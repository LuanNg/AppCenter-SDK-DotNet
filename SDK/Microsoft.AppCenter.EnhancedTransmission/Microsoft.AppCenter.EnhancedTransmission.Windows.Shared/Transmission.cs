using Microsoft.AppCenter.Analytics.Ingestion.Models;
using Microsoft.AppCenter.Ingestion.Models;
using Microsoft.AppCenter.Channel;
using Microsoft.AppCenter.Ingestion.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                channelGroup.FilteringLogs += ChannelGroup_FilteringLogs;

                ApplyEnabledState(InstanceEnabled);
            }
        }

        private void ChannelGroup_FilteringLogs(object sender, FilterLogsEventArgs e)
        {
            var analyticsLogs = e.Logs.Where(a => a.GetType() == typeof(EventLog)).ToList();

            // this is a little brute force, and slow. It would be better to use a hash set or push the filtering upstream (maybe)
            // ie var handledLogs = new HashSet<Log>(e.Logs.Where(a => a.GetType() == typeof(EventLog)));
            var original = e.Logs.ToList();
            original.RemoveAll(a => analyticsLogs.Contains(a));
            e.FilteredLogs = original;
        }

        private void ApplyEnabledState(bool enabled)
        {
            lock (_serviceLock)
            {
                if (enabled)
                {
                    // module specific
                    
                }
            }

            #endregion
        }
    }
}
