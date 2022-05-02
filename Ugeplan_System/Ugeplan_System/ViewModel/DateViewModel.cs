using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.ViewModel
{
    public class DateViewModel
    {
        public DateTime ScheduleDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int EmployeeId { get; set; }

        public DateViewModel()
        {

        }

        public DateViewModel(DateTime scheduleDate, string startTime, string endTime, int employeeId)
        {
            ScheduleDate = scheduleDate;
            StartTime = startTime;
            EndTime = endTime;
            EmployeeId = employeeId;
        }

        public override string ToString()
        {
            return $"{ScheduleDate} - {StartTime} : {EndTime}";
        }
    }
}
