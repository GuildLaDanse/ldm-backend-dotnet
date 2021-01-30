using System;
using System.Collections.Generic;
using System.Globalization;
using LaDanse.Application.Events.Models;

namespace LaDanse.WebUI.Models.Calendar
{
    public class DayModel
    {
        private readonly DateTime _day;
        private readonly RaidWeekModel _raidWeekModel;
        private List<Event> _events;
        private bool _showMonth;

        public DayModel(DateTime day, RaidWeekModel raidWeekModel) 
        {
            _day = day.Date;
            _raidWeekModel = raidWeekModel;
            _events = new List<Event>();
            _showMonth = false;
        }

        public DateTime Day()
        {
            return _day;
        }

        public IEnumerable<Event> Events()
        {
            return _events;
        }

        public bool IsInThePast()
        {
            var todayDate = DateTime.Today;
            
            return Day().CompareTo(todayDate) < 0;
        }

        public bool ShowMonth()
        {
            return _showMonth;
        }

        public void ShowMonth(bool showMonth) 
        {
            _showMonth = showMonth;
        }

        public bool IsInRaidWeek()
        {
            return _raidWeekModel.IsInRaidWeek(_day);
        }

        public bool IsToday()
        {
            return Day().Equals(DateTime.Today);
        }

        public string DisplayString()
        {
            return Day().ToString(ShowMonth() ? "MMM dd" : "dd", CultureInfo.CreateSpecificCulture("en-US"));
        }

        public void AddEvent(Event @event) 
        {
            _events.Add(@event);
        }

        public void ResetEvents()
        {
            _events.Clear();
        }
    }
}