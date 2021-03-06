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
        private List<Date> dates = new();
        private readonly string connStr = "Server=10.56.8.36;Database=PEDB03;User Id=PE-03;Password=OPENDB_03";

        public DateRepo()
        {
            InitializeRepo();
        }

        public void InitializeRepo()
        {
            Date date;

            using(SqlConnection conn = new(connStr))
            {
                conn.Open();

                SqlCommand command = new("SELECT DateId, ThisDate, StartTime, EndTime, EmployeeId, WorkFromHome FROM DateTable", conn);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        date = new Date();
                        date.DateId = int.Parse(reader["DateId"].ToString());
                        date.ScheduleDate = DateTime.Parse(reader["ThisDate"].ToString());
                        date.StartTime = reader["StartTime"].ToString();
                        date.EndTime = reader["EndTime"].ToString();
                        date.EmployeeId = int.Parse(reader["EmployeeId"].ToString());
                        if (reader["WorkFromHome"].ToString() == "True")
                        {
                            date.WorkFromhome = true;
                        }
                        else
                        {
                            date.WorkFromhome = false;
                        }
                        

                        dates.Add(date);
                    }
                }
            }
        }

        public void AddDate(DateTime date, string start, string end, int employeeId, bool workFromHome)
        {
            Date newDate = new();
            newDate.DateId = dates.Count;
            newDate.ScheduleDate = date;
            newDate.StartTime = start;
            newDate.EndTime = end;
            newDate.EmployeeId = employeeId;
            newDate.WorkFromhome = workFromHome;

            dates.Add(newDate);

            using(SqlConnection conn = new(connStr))
            {
                conn.Open();
                SqlCommand command = new("INSERT INTO dbo.DateTable(ThisDate, StartTime, EndTime, EmployeeId, WorkFromHome)" +
                                                    "VALUES (@thisDate, @startTime, @endTime, @employeeId, @workFromHome)", conn);
                command.Parameters.Add("@thisDate", System.Data.SqlDbType.DateTime2).Value = newDate.ScheduleDate;
                command.Parameters.Add("@startTime", System.Data.SqlDbType.NVarChar).Value = newDate.StartTime;
                command.Parameters.Add("@endTime", System.Data.SqlDbType.NVarChar).Value = newDate.EndTime;
                command.Parameters.Add("@employeeId", System.Data.SqlDbType.Int).Value = newDate.EmployeeId;
                if (newDate.WorkFromhome)
                {
                    command.Parameters.Add("@workFromHome", System.Data.SqlDbType.Bit).Value = 1;
                }
                else
                {
                    command.Parameters.Add("@workFromHome", System.Data.SqlDbType.Bit).Value = 0;
                }
                command.ExecuteNonQuery();
            }
        }

        public void RemoveDate(Date oldDate)
        {
            if (dates.Contains(oldDate))
            {
                dates.Remove(oldDate);
                
                using(SqlConnection conn = new(connStr))
                {
                    conn.Open();

                    SqlCommand command = new("DELETE FROM DateTable WHERE DateId = @dateId;", conn);

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

                using(SqlConnection conn = new(connStr))
                {
                    conn.Open();

                    SqlCommand command = new("UPDATE DateTable SET StartTime = @newStart, EndTime = @newEnd" +
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
