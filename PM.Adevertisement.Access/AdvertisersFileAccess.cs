using System;
using System.Collections.Generic;
using System.IO;
using PM.Adevertisement.Access.Helpers;

namespace PM.Adevertisement.Access
{
    internal class AdvertisersFileAccess : IAdvertisersAccess
    {
        private const string AdvertiserList = @"DataFiles\advertisers.txt"; //TODO: Move to config file
        private readonly IFileToObjectMapper<Advertiser> _fileToObjectMapper;

        public AdvertisersFileAccess(IFileToObjectMapper<Advertiser> fileToObjectMapper)
        {
            _fileToObjectMapper = fileToObjectMapper;
        }

        public IEnumerable<Advertiser> GetAdvertisers()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, AdvertiserList);
            var advertisers = _fileToObjectMapper.Read(path, true);

            Console.WriteLine($"{advertisers.Count} advertisers read from file."); //TODO: This should be a trace/log entry 

            return advertisers;
        }
    }
}