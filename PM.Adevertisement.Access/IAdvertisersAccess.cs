using System.Collections.Generic;

namespace PM.Adevertisement.Access
{
    public interface IAdvertisersAccess
    {
        IEnumerable<Advertiser> GetAdvertisers();
    }
}