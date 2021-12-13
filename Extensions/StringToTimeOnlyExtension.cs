using System.Text.RegularExpressions;

namespace IQAlert.Extensions
{
    internal static class StringToTimeOnlyExtension
    {
        internal static TimeOnly ToTimeOnly(this string time)
        {
            if (Regex.IsMatch(time, @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
            {
                string[] TimeSeparated = time.Split(':');
                int[] Time = new int[2];
                for (int i = 0; i < TimeSeparated.Length; i++)
                {
                    if (int.TryParse(TimeSeparated[i], out int CurrentTime))
                        Time[i] = CurrentTime;
                    else
                        throw new FormatException();
                }
                return new TimeOnly(Time[0], Time[1]);
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
