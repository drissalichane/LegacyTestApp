using System;
using System.Collections;

namespace LegacyWebApi.Services
{
    [Obsolete("Use INewService instead.")]
    public class LegacyService
    {
        public void DoSomethingLegacy()
        {
            // Using ArrayList instead of generic List<T>
            ArrayList list = new ArrayList();
            list.Add("Legacy item");

            // Older way of doing things that might be migrated
            var appDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Running in: {appDomain.FriendlyName}");
        }

        [Obsolete("Thread.Abort is obsolete in .NET Core and .NET 5+.")]
        public void ConnectToDatabase(System.Threading.CancellationToken cancellationToken = default)
        {
            // Thread.Abort is considered legacy/obsolete
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
