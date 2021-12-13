using IQAlert.Enums;
using System.Text.Json.Serialization;

namespace IQAlert.Model
{
    internal class Signal
    {
        public string? Exchange { get; set; }
        public string? StartTime { get; set; }
        [JsonIgnore]
        public TimeOnly GetStartTime { get => ConvertStringToTimeOnly(); }
        [JsonIgnore]
        public bool AlreadyNotified { get; set; } = false;
        public Side Side { get; set; }

        private TimeOnly ConvertStringToTimeOnly()
        {
            return new TimeOnly(Convert.ToInt32(StartTime[..2]),
                Convert.ToInt32(StartTime[3..]));
        }
    }
}
