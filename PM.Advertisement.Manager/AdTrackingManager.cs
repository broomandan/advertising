using System.Collections.Generic;
using PM.Adevertisement.Access;
using PM.Advertisement.Engine;

namespace PM.Advertisement.Manager
{
    public class AdTrackingManager : IAdTrackingManager
    {
        private readonly IAdvertisersAccess _advertisersAccess;
        private readonly IDuplicateDetectorEngine _duplicateDetectorEngine;

        public AdTrackingManager(IDuplicateDetectorEngine duplicateDetectorEngine, IAdvertisersAccess advertisersAccess)
        {
            _advertisersAccess = advertisersAccess;
            _duplicateDetectorEngine = duplicateDetectorEngine;
        }

        public IDictionary<string, List<Advertiser>> DetectDuplicatesAdvertisers()
        {
            // TODO: The size of returned list might need to be managed for performance reasons. Perhaps with pagination/batching mechanism
            var advertisers = _advertisersAccess.GetAdvertisers();

            var duplicates = _duplicateDetectorEngine.FindDuplicates(advertisers);
            return duplicates;
        }
    }
}