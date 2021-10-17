using System;

namespace RoadStatus.Helpers
{
    public static class ParametersHelper
    {
        public static void ValidateParameters(string[] parameters)
        {
            if (parameters.Length < 1)
            {
                throw new Exception("Road name is missing");
            }
        }
    }
}
