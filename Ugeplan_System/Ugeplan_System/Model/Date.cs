using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class Date
    {
        public int DateId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int EmployeeId { get; set; }
        public bool WorkFromhome { get; set; }

        public Date()
        {

        }

        public Date( DateTime scheduleDate, string startTime, string endTime, bool workFromHome)
        {
            ScheduleDate = scheduleDate;
            StartTime = startTime;
            EndTime = endTime;
            WorkFromhome = workFromHome;
        }

        public override string ToString()
        {
            return $"{ScheduleDate} - {StartTime} : {EndTime}";
        }
    }
}
