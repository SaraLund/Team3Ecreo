using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class DateRepo
    {
        private List<Date> dates = new List<Date>();
        private static readonly string connStr = "Server=10.56.8.36;Database=PEDB03;User Id=PE-03;Password=OPENDB_03";

        public DateRepo()
        {
            InitializeRepo();
        }

        public void InitializeRepo()
        {
            Date date;

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT DateId, WeekDayName, StartTime, EndTime, EmployeeId FROM DateTable", conn);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        date = new Date();
                        date.DateId = int.Parse(reader["DateId"].ToString());
                        date.Day = reader["WeekDayName"].ToString();
                        date.ScheduleDate = DateTime.Parse(reader["ThisDate"].ToString());
                        date.StartTime = reader["StartTime"].ToString();
                        date.EndTime = reader["EndTime"].ToString();
                        date.EmployeeId = int.Parse(reader["EmployeeId"].ToString());

                        dates.Add(date);
                    }
                }
            }
        }

        public void AddDate(DateTime date, string start, string end, int employeeId)
        {
            Date newDate = new Date();
            newDate.DateId = dates.Count;
            newDate.Day = date.DayOfWeek.ToString();
            newDate.ScheduleDate = date;
            newDate.StartTime = start;
            newDate.EndTime = end;
            newDate.EmployeeId = employeeId;

            dates.Add(newDate);

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.DateTable(WeekDayName, ThisDate, StartTime, EndTime, EmployeeId)" +
                                                    "VALUES (@weekDayName, @thisDate, @startTime, @endTime, @employeeId)", conn);
                command.Parameters.Add("@weekDayName", System.Data.SqlDbType.NVarChar).Value = newDate.Day;
                command.Parameters.Add("@thisDate", System.Data.SqlDbType.DateTime2).Value = newDate.ScheduleDate;
                command.Parameters.Add("@startTime", System.Data.SqlDbType.NVarChar).Value = newDate.StartTime;
                command.Parameters.Add("@endTime", System.Data.SqlDbType.NVarChar).Value = newDate.EndTime;
                command.Parameters.Add("@employeeId", System.Data.SqlDbType.Int).Value = newDate.EmployeeId;
                command.ExecuteNonQuery();
            }
        }

        public void RemoveDate(Date oldDate)
        {
            if (dates.Contains(oldDate))
            {
                dates.Remove(oldDate);
                
                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM DateTable WHERE DateId = @dateId;", conn);

                    command.Parameters.Add("@dateId", System.Data.SqlDbType.Int).Value = oldDate.DateId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDate(int dateId, string newStart, string newEnd)
        {
            if(dates.Exists(d => d.DateId == dateId))
            {
                Date temp = dates.Find(d => d.DateId == dateId);
                temp.StartTime = newStart;
                temp.EndTime = newEnd;

                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE DateTable SET StartTime = @newStart, EndTime = @newEnd" +
                                                        "WHERE DateId = @dateId", conn);
                    command.Parameters.Add("@newStart", System.Data.SqlDbType.NVarChar).Value = newStart;
                    command.Parameters.Add("@newEnd", System.Data.SqlDbType.NVarChar).Value = newEnd;
                    command.Parameters.Add("@dateId", System.Data.SqlDbType.Int).Value = dateId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Date> GetAllDates()
        {
            return dates;
        }

        public Date GetDateById(int dateId)
        {
            if(!dates.Exists(d => d.DateId == dateId))
            {
                return null;
            }
            return dates.Find(d => d.DateId == dateId);
        }
    }
}
