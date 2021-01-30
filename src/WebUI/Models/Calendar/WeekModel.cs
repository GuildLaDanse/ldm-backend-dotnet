using System;
using System.Collections.Generic;
using LaDanse.Application.Events.Models;

namespace LaDanse.WebUI.Models.Calendar
{
    public class WeekModel
    {
        private readonly DateTime _firstDay;
        private readonly List<DayModel> _days;

        public WeekModel(DateTime firstDay, RaidWeekModel raidWeekModel) 
        {
            _firstDay = firstDay.Date;
            _days = new List<DayModel>();
            
            for (var firstDateDelta = 0; firstDateDelta < 7; firstDateDelta++)
            {
                var weekStart = _firstDay.AddDays(firstDateDelta);

                var dayModel = new DayModel(weekStart, raidWeekModel);

                dayModel.ShowMonth(weekStart.Day == 1);

                _days.Add(dayModel);
            }
        }

        public DateTime FirstDay()
        {
            return _firstDay;
        }

        public IEnumerable<DayModel> Days()
        {
            return _days;
        }

        public bool IsInWeek(DateTime day)
        {
            var lastDay = _firstDay.AddDays(6);

            return _firstDay.Date.Equals(day.Date)
                   || lastDay.Date.Equals(day.Date)
                   || (
                       _firstDay.Date.CompareTo(day.Date) < 0
                       &&
                       lastDay.Date.CompareTo(day.Date) > 0
                   );
        }

        public void AddEvent(Event @event) 
        {
            foreach (var currentDay in _days)
            {
                if (@event.InviteTime.Date.Equals(currentDay.Day()))    
                {
                    currentDay.AddEvent(@event);
                }
            }
        }

        public void ResetEvents()
        {
            foreach (var currentDay in _days)
            {
                currentDay.ResetEvents();
            }
        }
    }
}