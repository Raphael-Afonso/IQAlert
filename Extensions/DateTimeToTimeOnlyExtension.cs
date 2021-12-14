namespace IQAlert.Extensions
{
    internal static class DateTimeToTimeOnlyExtension
    {
        internal static TimeOnly ToTimeOnly(this DateTime dateTime) =>
             new(dateTime.Hour, dateTime.Minute);
    }
}
