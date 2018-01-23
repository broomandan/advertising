using System.Collections.Concurrent;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PM.Adevertisement.Access;
using PM.Advertisement.Engine;

namespace PM.Advertisement.Manager.Test
{
    [TestFixture]
    public class AdTrackingManagerTests
    {
        private IAdTrackingManager _sut;
        private Mock<IAdvertisersAccess> _advertisersAccess;
        private Mock<IDuplicateDetectorEngine> _duplicateDetectorEngine;

        [SetUp]
        public void SetUp()
        {
            _duplicateDetectorEngine = new Mock<IDuplicateDetectorEngine>();
            _advertisersAccess = new Mock<IAdvertisersAccess>();

            _sut = new AdTrackingManager(_duplicateDetectorEngine.Object, _advertisersAccess.Object);
        }

        [Test]
        public void ShouldDetectDuplicatesAdvertisers()
        {
            _sut.DetectDuplicatesAdvertisers();

            _advertisersAccess.Verify(x => x.GetAdvertisers());
            _duplicateDetectorEngine.Verify(x => x.FindDuplicates(It.IsAny<IEnumerable<Advertiser>>()));
        }

        [Test]
        public void ShouldDetectDuplicatesAdvertisersWhenProvidedWithAListContainingDuplicateEntries()
        {
            var duplicatesList = new Dictionary<string, List<Advertiser>>
            {
                {
                    "duplicatekey", new List<Advertiser>
                    {
                        new Advertiser {Name = "duplicate 1"},
                        new Advertiser {Name = "duplicate1"}
                    }
                }
            };

            _advertisersAccess
                .Setup(x => x.GetAdvertisers())
                .Returns(new List<Advertiser>());

            _duplicateDetectorEngine
                .Setup(x => x.FindDuplicates(It.IsAny<List<Advertiser>>()))
                .Returns(duplicatesList);

            var actual = _sut.DetectDuplicatesAdvertisers();

            Assert.That(actual.Count, Is.EqualTo(1));

            _sut.DetectDuplicatesAdvertisers();

            _advertisersAccess.VerifyAll();
            _duplicateDetectorEngine.VerifyAll();
        }
    }
}