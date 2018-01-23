using PM.Adevertisement.Access.Helpers;

namespace PM.Adevertisement.Access
{
    public class ObjectFactory
    {
        public static IAdvertisersAccess CreateAdvertisersFileAccessInstance()
        {
            return new AdvertisersFileAccess(new FileToObjectMapper<Advertiser>('|'));
        }
    }
}