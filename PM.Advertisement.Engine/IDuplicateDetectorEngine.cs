using System.Collections.Generic;
using PM.Adevertisement.Access;

namespace PM.Advertisement.Engine
{
    public interface IDuplicateDetectorEngine
    {
        IDictionary<string, List<Advertiser>> FindDuplicates(IEnumerable<Advertiser> advertisers);
    }
}