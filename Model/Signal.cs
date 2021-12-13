using IQAlert.Enums;
using IQAlert.Extensions;
using System.Text.Json.Serialization;

namespace IQAlert.Model
{
    internal class Signal
    {
        internal string Exchange { get; set; }
        internal string StartTime { get; set; }
        [JsonIgnore]
        internal TimeOnly GetStartTime { get => StartTime.ToTimeOnly(); }
        [JsonIgnore]
        internal bool IsNotified { get; set; } = false;
        internal Side Side { get; set; }

        internal Signal(string exchange, string startTime, Side side)
        {
            Exchange = exchange;
            StartTime = startTime;
            Side = side;
        }
    }
}
