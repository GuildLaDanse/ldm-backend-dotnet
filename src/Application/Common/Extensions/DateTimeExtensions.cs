using System;

namespace LaDanse.Application.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds = 0, int milliseconds = 0)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
    }
}