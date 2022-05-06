using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.ViewModel
{
    public class MeetingViewModel
    {
        public int MeetingId { get; set; }
        public string Room { get; set; }
        public string MeetingDescription { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime MeetingDate { get; set; }
        public bool OnlineMeeting { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

        public MeetingViewModel()
        {

        }

        public MeetingViewModel(string room, string meetingDescription, string startTime, string endTime, DateTime meetingDate, bool onlineMeeting, List<EmployeeViewModel> employees)
        {
            Room = room;
            MeetingDescription = meetingDescription;
            StartTime = startTime;
            EndTime = endTime;
            MeetingDate = meetingDate;
            OnlineMeeting = onlineMeeting;
            Employees = employees;
        }

        public override string ToString()
        {
            return $"{Room} : {MeetingDescription}: {MeetingDate} - {StartTime} : {EndTime} : {OnlineMeeting}";
        }
    }
}
