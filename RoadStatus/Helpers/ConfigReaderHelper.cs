using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using RoadStatus.Entities;

namespace RoadStatus.Helpers
{
    public static class ConfigReaderHelper
    {
        public const string configFileName = "appConfig.json";
        public static  Config LoadConfig()
        {
            if (!ConfigFileExists())
            {
                throw new Exception($"{configFileName} file doesn't exist, create one based on the readme file");
            }

            var config = new Config();

            try
            {
                var configRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(configFileName, optional:false).Build();

                configRoot.Bind(config);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not parse the {configFileName}, make sure it is a valid json file");
            }

            ValidateConfig(config);

            return config;
        }

        private static bool ConfigFileExists()
        {
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), configFileName));
        }

        private static  void ValidateConfig(Config config)
        {

            var validAppId = config.AppId != null;
            var validApiKey = config.ApiKey != null;

            if (!validAppId || !validApiKey)
            {
                var error = new StringBuilder();
                if (!validAppId)
                {
                    error.AppendLine("AppId is not in the correct format");
                }

                if (!validApiKey)
                {
                    error.AppendLine("ApiKey is not in the correct format");
                }

                throw new Exception("Configuration file has the following error(s):" + Environment.NewLine + error.ToString());
            }
        }
    }
}
