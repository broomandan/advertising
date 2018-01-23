using System;
using System.Collections.Generic;
using PM.Adevertisement.Access;
using PM.Advertisement.Manager;

namespace PM.Advertisement.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TODO: use IOC container 
                IAdTrackingManager adTrackingManager = Manager.ObjectFactory.CreateAdTrackingManagerInstance();
                var duplicatesDictionary = adTrackingManager.DetectDuplicatesAdvertisers();

                foreach (var duplicateEntry in duplicatesDictionary)
                {
                    PrintDuplicateEntry(duplicateEntry);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine("\r\nPress Enter to exit.");
            Console.ReadLine();
        }

        private static void PrintDuplicateEntry(KeyValuePair<string, List<Advertiser>> duplicateEntry)
        {
            Console.WriteLine($"Below advertisers share the same unique key {duplicateEntry.Key}:");
            foreach (var advertiser in duplicateEntry.Value)
            {
                Console.WriteLine(advertiser.Name);
            }

            Console.WriteLine($"*****************************************************************");
        }
    }
}