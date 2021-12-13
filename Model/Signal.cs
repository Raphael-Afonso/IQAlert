using IQAlert.Enums;
using IQAlert.Extensions;
using System.Text.Json.Serialization;

namespace IQAlert.Model
{
    public class Signal
    {
        public string Exchange { get; set; }
        public string StartTime { get; set; }
        public Side Side { get; set; }
        [JsonIgnore]
        public TimeOnly GetStartTime { get => StartTime.ToTimeOnly(); }
        [JsonIgnore]
        public bool IsNotified { get; set; } = false;

        public Signal(string exchange, string startTime, Side side)
        {
            Exchange = exchange;
            StartTime = startTime;
            Side = side;
        }
    }
}
