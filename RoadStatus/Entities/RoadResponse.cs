using System;

namespace RoadStatus.Entities
{
    public class RoadResponse
    {
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }

        public override string ToString()
        {
            if (DisplayName != null &&
                StatusSeverity != null &&
                StatusSeverityDescription != null)
            {
                return $"The status of the {DisplayName} is as follows" + Environment.NewLine +
                       $"       Road Status is {StatusSeverity}" + Environment.NewLine +
                       $"       Road Status Description is {StatusSeverityDescription}";
            }

            return "";
        }

    }
}
