using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using RoadStatus.Helpers;

namespace RoadStatus.Tests.Helpers
{
    public class ConfigReaderHelperTests
    {
        [SetUp]
        public void Setup()
        {
            File.Delete(ConfigReaderHelper.configFileName);
        }

        [Test]
        public void GetConfig_WhenFileDoesntExist_ShouldException()
        {
            Assert.That(ConfigReaderHelper.LoadConfig, Throws.Exception.Message.Contains("doesn't exist"));
        }

        [Test]
        public void GetConfig_WhenEmptyFileExists_ShouldException()
        {
            File.Create(ConfigReaderHelper.configFileName).Close();

            Assert.That(ConfigReaderHelper.LoadConfig, Throws.Exception.Message.Contains("Could not parse"));
        }

        [Test]
        public void GetConfig_WhenFileWithoutAppIdAndApiKeyExists_ShouldException()
        {
            File.Create(ConfigReaderHelper.configFileName).Close();
            var configFileContents = new
            {
                someRandomProperty = "useless value",
                anotherProperty = "something that isn't useful"
            };
            var json = JsonConvert.SerializeObject(configFileContents);
            File.WriteAllText(ConfigReaderHelper.configFileName, json);

            Assert.That(ConfigReaderHelper.LoadConfig, Throws.Exception.Message.Contains("Configuration file has the following error(s)"));
        }


        [Test]
        public void GetConfig_WhenFileWithNonEmptyAppIdAndApiKeyExists_ShouldNotException()
        {
            File.Create(ConfigReaderHelper.configFileName).Close();
            var configFileContents = new
            {
                appId = "not empty",
                apiKey = "not empty"
            };
            var json = JsonConvert.SerializeObject(configFileContents);
            File.WriteAllText(ConfigReaderHelper.configFileName, json);

            Assert.That(ConfigReaderHelper.LoadConfig, Throws.Nothing);

        }
    }
}
