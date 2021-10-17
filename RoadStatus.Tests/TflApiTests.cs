using NUnit.Framework;
using RoadStatus.Entities;

namespace RoadStatus.Tests
{
    public class TflApiTests
    {
        [Test]
        [TestCase("A2")]
        [TestCase("A222222")]
        public void GetRoadStatus_WithInvalidConfig_ShouldReturnException(string roadName)
        {
            var config = new Config()
            {
                ApiKey = "something_not_valid",
                AppId = "something_not_valid"
            };

            var tflApi = new TflApi(config);

            Assert.That(() => tflApi.GetRoadStatus(roadName), Throws.Exception.With.Message.Contains("Invalid"));
        }

        [Test]
        [TestCase("A2")]
        [TestCase("A222222")]
        public void GetRoadStatus_WithEmptyConfig_ShouldReturnException(string roadName)
        {
            var config = new Config()
            {
                ApiKey = "",
                AppId = ""
            };

            var tflApi = new TflApi(config);

            Assert.That(() => tflApi.GetRoadStatus(roadName), Throws.Exception.With.Message.Contains("Invalid"));
        }

        [Test]
        [TestCase("A1")]
        [TestCase("A2")]
        [TestCase("A3")]
        public void GetRoadStatus_WithValidConfigAndValidRoad_ShouldReturnTheStatus(string roadName)
        {
            var config = new Config()
            {
                ApiKey = "YOUR_API_KEY",
                AppId = "YOUR_APP_ID"
            };

            var tflApi = new TflApi(config);

            Assert.That(tflApi.GetRoadStatus(roadName), Is.TypeOf<RoadResponse>());
        }


        [Test]
        [TestCase("A1111111")]
        [TestCase("A2222222")]
        [TestCase("A3333333")]
        public void GetRoadStatus_WithValidConfigAndInvalidRoad_ShouldReturnException(string roadName)
        {
            var config = new Config()
            {
                ApiKey = "YOUR_API_KEY",
                AppId = "YOUR_APP_ID"
            };

            var tflApi = new TflApi(config);

            Assert.That(() => tflApi.GetRoadStatus(roadName), Throws.Exception.Message.Contains("not a valid road"));
        }
    }
}
