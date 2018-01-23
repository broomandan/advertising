using System.Collections.Generic;
using NUnit.Framework;
using PM.Adevertisement.Access;

namespace PM.Advertisement.Engine.Test
{
    [TestFixture]
    public class DuplicateDetectorEngineTests
    {
        IDuplicateDetectorEngine _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new DuplicateDetectorEngine();
        }

        [Test]
        public void ShouldFindNoDuplicateEntriesGivenAnEmptyListOfAdvertisers()
        {
            var actual = _sut.FindDuplicates(new List<Advertiser>());
            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void ShouldFindDuplicateEntriesGivenAListOfAdvertisersContainingTwoExactDuplicateEntries()
        {
            var advertisersListWithTwoDuplicateNames = new List<Advertiser>
            {
                new Advertiser {Name = "this will be exactly duplicated"},
                new Advertiser {Name = "no duplicate"},
                new Advertiser {Name = "this will be exactly duplicated"}
            };
            var actual = _sut.FindDuplicates(advertisersListWithTwoDuplicateNames);
            Assert.That(actual.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldFindDuplicateEntriesGivenAListOfAdvertisersContainingOneDuplicateEntries()
        {
            var advertisersListWithTwoDuplicateNames = new List<Advertiser>
            {
                new Advertiser {Name = "this will be not exactly duplicated "},
                new Advertiser {Name = "no duplicate"},
                new Advertiser {Name = "this --will *-=be not !!  -exactly ???duplicated? "},
            };
            var actual = _sut.FindDuplicates(advertisersListWithTwoDuplicateNames);
            Assert.That(actual.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldFindDuplicateEntriesGivenAListOfAdvertisersContainingMoreThanOneDuplicateEntries()
        {
            var advertisersListWithTwoDuplicateNames = new List<Advertiser>
            {
                new Advertiser {Name = "this will be not exactly duplicated "},
                new Advertiser {Name = "no duplicate"},
                new Advertiser {Name = "this --will *-=be not !!  -exactly ???duplicated? "},
                new Advertiser {Name = "1-800-Flowers.com"},
                new Advertiser {Name = "1800Flowers.com"},
            };
            var actual = _sut.FindDuplicates(advertisersListWithTwoDuplicateNames);
            Assert.That(actual.Count, Is.EqualTo(2));
        }
    }
}
