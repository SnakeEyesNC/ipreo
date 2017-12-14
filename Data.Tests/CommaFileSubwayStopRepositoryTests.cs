using System.IO;
using Ipreo.Data;
using Ipreo.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
    [TestClass]
    public class CommaFileSubwayStopRepositoryTests
    {
        private static CommaFileSubwayStopRepository SubwayStopRepo { get; set; }

        [ClassInitialize]
        public static void TestSuiteSetup(TestContext context)
        {
            string runningDirPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(runningDirPath, "DataFiles", @"stops.txt");
            SubwayStopRepo = new CommaFileSubwayStopRepository(filePath);
        }

        [TestMethod]
        public void FirstLineId_Equals101_True()
        {
            // Arrange
            string expectedId = "101";

            // Act
            SubwayStop stop = SubwayStopRepo.Get("101");

            // Assert
            Assert.IsNotNull(stop);
            Assert.AreEqual(expectedId, stop.Id);
        }

        [TestMethod]
        public void FirstLineLatitude_Equals101_True()
        {
            // Arrange
            string expectedId = "40.889248";

            // Act
            SubwayStop stop = SubwayStopRepo.Get("101");

            // Assert
            Assert.IsNotNull(stop);
            Assert.AreEqual(expectedId, stop.Latitude);
        }
    }
}
