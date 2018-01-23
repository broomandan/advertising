using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PM.Adevertisement.Access;

namespace PM.Advertisement.Engine
{
    public class DuplicateDetectorEngine : IDuplicateDetectorEngine
    {
        private readonly Regex _regexService = new Regex("[^a-zA-Z0-9]");

        //TODO: size of input to this method impacts its performance 
        public IDictionary<string, List<Advertiser>> FindDuplicates(IEnumerable<Advertiser> advertisers)
        {
            var advertiserNameAndListOfDuplicates = new Dictionary<string, List<Advertiser>>();

            foreach (var advertiser in advertisers)
            {
                var advertiserUniqueName = GenerateAdvertiserUniqueName(advertiser);
                if (advertiserNameAndListOfDuplicates.ContainsKey(advertiserUniqueName))
                {
                    var duplicateList = advertiserNameAndListOfDuplicates[advertiserUniqueName];
                    duplicateList.Add(advertiser);
                }
                else
                {
                    var duplicateList = new List<Advertiser> {advertiser};
                    advertiserNameAndListOfDuplicates.Add(advertiserUniqueName, duplicateList);
                }
            }

            var result = advertiserNameAndListOfDuplicates
                .Where(kvp => kvp.Value.Count > 1)
                .ToDictionary(key => key.Key, value => value.Value);
            return result;
        }

        private string GenerateAdvertiserUniqueName(Advertiser advertiser)
        {
            return _regexService.Replace(advertiser.Name, string.Empty);
        }
    }
}