using System;

namespace LaDanse.WebUI.Models.Calendar
{
    public class RaidWeekModel
    {
        private DateTime _firstDay;
        private DateTime _lastDay;

        public RaidWeekModel(DateTime showDate) 
        {
            Init(showDate);
        }

        public DateTime FirstDay()
        {
            return _firstDay;
        }

        public DateTime LastDay()
        {
            return _lastDay;
        }

        public bool IsInRaidWeek(DateTime givenDate)
        {
            return _firstDay.Date.Equals(givenDate.Date)
                   || _lastDay.Date.Equals(givenDate.Date)
                   || (
                       _firstDay.Date.CompareTo(givenDate.Date) < 0
                       &&
                       _lastDay.Date.CompareTo(givenDate.Date) > 0
                   );
        }

        private void Init(DateTime showDate) 
        {
            var deltaToStart = 0;
            var deltaToEnd = 0;
            
            switch (showDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    deltaToStart = 5;
                    deltaToEnd   = 1;
                    break;
                case DayOfWeek.Tuesday: // end of raid week
                    deltaToStart = 6;
                    deltaToEnd   = 0;
                    break;
                case DayOfWeek.Wednesday: // start of raid week
                    deltaToStart = 0;
                    deltaToEnd   = 6;
                    break;
                case DayOfWeek.Thursday:
                    deltaToStart = 1;
                    deltaToEnd   = 5;
                    break;
                case DayOfWeek.Friday:
                    deltaToStart = 2;
                    deltaToEnd   = 4;
                    break;
                case DayOfWeek.Saturday:
                    deltaToStart = 3;
                    deltaToEnd   = 3;
                    break;
                case DayOfWeek.Sunday:
                    deltaToStart = 4;
                    deltaToEnd   = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            } 
            
            _firstDay = showDate.AddDays(-deltaToStart);
            _lastDay = showDate.AddDays(deltaToEnd);
        }
    }
}