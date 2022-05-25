using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class MeetingRepo
    {
        List<Meeting> meetings = new List<Meeting>();
        private readonly string connStr = "Server=10.56.8.36;Database=PEDB03;User Id=PE-03;Password=OPENDB_03";
        private List<Employee> employees;

        public MeetingRepo(List<Employee> employees)
        {
            this.employees = employees;
            InitializeRepo();
        }

        public void InitializeRepo()
        {
            Meeting meeting;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT MeetingId, MeetingDescription, StartTime, " +
                                                    "EndTime, MeetingDate, OnlineMeeting, Room, Initials FROM Meeting", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        meeting = new Meeting();
                        meeting.MeetingId = int.Parse(reader["MeetingId"].ToString());
                        meeting.MeetingDescription = reader["MeetingDescription"].ToString();
                        meeting.StartTime = reader["StartTime"].ToString();
                        meeting.EndTime = reader["EndTime"].ToString();
                        meeting.MeetingDate = DateTime.Parse(reader["MeetingDate"].ToString());
                        if (reader["OnlineMeeting"].ToString() == "True")
                        {
                            meeting.OnlineMeeting = true;
                        }
                        else
                        {
                            meeting.OnlineMeeting = false;
                        }
                        meeting.Room = reader["Room"].ToString();

                        string[] temp = reader["Initials"].ToString().Split(';');
                        List<Employee> tempEmployees = new();
                        foreach (string s in temp)
                        {
                            tempEmployees.Add(employees.Find(e => e.Initials == s));
                        }
                        meeting.Employees = tempEmployees;

                        meetings.Add(meeting);
                    }
                }
            }
        }

        public void AddMeeting(string meetingDescription, string startTime, string endTime, DateTime meetingDate, bool onlineMeeting, List<Employee> employees, string room, string initials)
        {
            Meeting m = new Meeting();
            m.MeetingId = meetings.Count;
            m.MeetingDescription = meetingDescription;
            m.StartTime = startTime;
            m.EndTime = endTime;
            m.MeetingDate = meetingDate;
            m.OnlineMeeting = onlineMeeting;
            m.Employees = employees;
            m.Room = room;

            meetings.Add(m);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Meeting(MeetingDescription, StartTime, EndTime, MeetingDate, OnlineMeeting, Room, Initials)" +
                                                    "VALUES (@meetingDescription, @startTime, @endTime, @meetingDate, @onlineMeeting, @room, @initials)", conn);
                command.Parameters.Add("@meetingDescription", System.Data.SqlDbType.NVarChar).Value = m.MeetingDescription;
                command.Parameters.Add("@startTime", System.Data.SqlDbType.NVarChar).Value = m.StartTime;
                command.Parameters.Add("@endTime", System.Data.SqlDbType.NVarChar).Value = m.EndTime;
                command.Parameters.Add("@meetingDate", System.Data.SqlDbType.DateTime2).Value = m.MeetingDate;
                if (m.OnlineMeeting)
                {
                    command.Parameters.Add("@onlineMeeting", System.Data.SqlDbType.Bit).Value = 1;
                }
                else
                {
                    command.Parameters.Add("@onlineMeeting", System.Data.SqlDbType.Bit).Value = 0;
                }
                command.Parameters.Add("@room", System.Data.SqlDbType.NVarChar).Value = m.Room;
                command.Parameters.Add("@initials", System.Data.SqlDbType.NVarChar).Value = initials;
                command.ExecuteNonQuery();
            }
        }

        public void RemoveMeeting(Meeting oldMeeting)
        {
            if (meetings.Contains(oldMeeting))
            {
                meetings.Remove(oldMeeting);

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM Meeting WHERE MeetingId = @meetingId;", conn);

                    command.Parameters.Add("@meetingId", System.Data.SqlDbType.Int).Value = oldMeeting.MeetingId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMeeting(int meetingId, string meetingDescription, string startTime, string endTime, DateTime meetingDate, bool onlineMeeting, List<Employee> employees, string room)
        {
            if (meetings.Exists(m => m.MeetingId == meetingId))
            {
                Meeting temp = meetings.Find(m => m.MeetingId == meetingId);
                temp.MeetingDescription = meetingDescription;
                temp.StartTime = startTime;
                temp.EndTime = endTime;
                temp.MeetingDate = meetingDate;
                temp.OnlineMeeting = onlineMeeting;
                temp.Employees = employees;
                temp.Room = room;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Meeting SET MeetingDescription = @meetingDescription, StartTime = @startTime, EndTime = @endTime, MeetingDate = @meetingDate, OnlineMeeting = @onlineMeeting, Room = @room" +
                                                        "WHERE MeetingId = @meetingId", conn);

                    command.Parameters.Add(@meetingDescription, System.Data.SqlDbType.NVarChar).Value = meetingDescription;
                    command.Parameters.Add(@startTime, System.Data.SqlDbType.NVarChar).Value = startTime;
                    command.Parameters.Add(@endTime, System.Data.SqlDbType.NVarChar).Value = endTime;
                    command.Parameters.Add("@meetingDate", System.Data.SqlDbType.DateTime2).Value = meetingDate;
                    if (onlineMeeting)
                    {
                        command.Parameters.Add("@onlineMeeting", System.Data.SqlDbType.Bit).Value = 1;
                    }
                    else
                    {
                        command.Parameters.Add("@onlineMeeting", System.Data.SqlDbType.Bit).Value = 0;
                    }
                    command.Parameters.Add(room, System.Data.SqlDbType.NVarChar).Value = room;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Meeting> GetAllMeeting()
        {
            return meetings;
        }

        public Meeting GetMeetingById(int meetingId)
        {
            if (!meetings.Exists(m => m.MeetingId == meetingId))
            {
                return null;
            }
            return meetings.Find(m => m.MeetingId == meetingId);
        }
    }
}
