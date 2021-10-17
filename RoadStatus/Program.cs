using System;
using RoadStatus.Helpers;

namespace RoadStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = ConfigReaderHelper.LoadConfig();
                ParametersHelper.ValidateParameters(args);

                var roadName = args[0];

                var tflApi = new TflApi(config);
                var roadStatus = tflApi.GetRoadStatus(roadName);
                Console.WriteLine(roadStatus.ToString());

                Environment.ExitCode = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.ExitCode = 1;
            }

        }
    }
}
