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
        public string Day { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int EmployeeId { get; set; }

        public Date()
        {

        }

        public Date(string day, DateTime scheduleDate, string startTime, string endTime)
        {
            Day = day;
            ScheduleDate = scheduleDate;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"{Day}, {ScheduleDate} - {StartTime} : {EndTime}";
        }
    }
}
