using System.Collections.Generic;
using PM.Adevertisement.Access;

namespace PM.Advertisement.Manager
{
    public interface IAdTrackingManager
    {
        IDictionary<string, List<Advertiser>> DetectDuplicatesAdvertisers();
    }
}