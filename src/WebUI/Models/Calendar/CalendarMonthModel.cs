using System;
using System.Collections.Generic;
using System.Linq;
using LaDanse.Application.Events.Models;

namespace LaDanse.WebUI.Models.Calendar
{
    public class CalendarMonthModel
    {
        private readonly DateTime _firstDay;
        private readonly List<WeekModel> _weeks;

        private static DateTime CalculateFirstDay(DateTime showDay, RaidWeekModel raidWeekModel)
        {
            var firstDay = GetClosestMondayBefore(showDay);

            return raidWeekModel.IsInRaidWeek(firstDay) ? firstDay.AddDays(-7) : firstDay;
        }

        private static DateTime GetClosestMondayBefore(DateTime showDay)
        {
            return showDay.DayOfWeek switch
            {
                DayOfWeek.Monday => showDay,
                DayOfWeek.Tuesday => showDay.AddDays(-1),
                DayOfWeek.Wednesday => showDay.AddDays(-2),
                DayOfWeek.Thursday => showDay.AddDays(-3),
                DayOfWeek.Friday => showDay.AddDays(-4),
                DayOfWeek.Saturday => showDay.AddDays(-5),
                DayOfWeek.Sunday => showDay.AddDays(-6),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public CalendarMonthModel(DateTime showDay, RaidWeekModel raidWeekModel)
        {
            _firstDay = CalculateFirstDay(showDay, raidWeekModel);
            _weeks = new List<WeekModel>();

            var firstWeekDay = _firstDay;

            for (var i = 0; i < 4; i++)
            {
                var weekModel = new WeekModel(firstWeekDay, raidWeekModel);

                _weeks.Add(weekModel);

                firstWeekDay = firstWeekDay.AddDays(7);
            }

            _weeks.First().Days().First().ShowMonth(true);
        }

        public DateTime FirstDay()
        {
            return _firstDay;
        }

        public IEnumerable<WeekModel> Weeks()
        {
            return _weeks;
        }

        public DateTime GetStartOfPreviousMonth()
        {
            return _firstDay.AddDays(-28);
        }

        public DateTime GetStartOfNextMonth()
        {
            return _firstDay.AddDays(28);
        }

        public void PopulateEvents(IEnumerable<Event> events)
        {
            ResetEvents();

            foreach (var currentEvent in events)
            {
                foreach (var currentWeek in _weeks)
                {
                    if (currentWeek.IsInWeek(currentEvent.InviteTime.Date))
                    {
                        currentWeek.AddEvent(currentEvent);
                    }
                }
            }
        }

        private void ResetEvents()
        {
            foreach (var currentWeek in _weeks)
            {
                currentWeek.ResetEvents();
            }
        }
    }
}