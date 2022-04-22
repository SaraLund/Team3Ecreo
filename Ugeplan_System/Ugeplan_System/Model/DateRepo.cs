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
        private static readonly string connStr = "Server=10.56.8.36;Datebase=PEDB03;User Id=PE-03;Password=OPENDB_03";

        public DateRepo()
        {
            InitializeRepo();
        }

        public void InitializeRepo()
        {

        }

        public void AddDate(DateTime date, string start, string end)
        {
            Date newDate = new Date();
            newDate.DateId = dates.Count;
            newDate.Day = date.DayOfWeek.ToString();
            newDate.ScheduleDate = date;
            newDate.StartTime = start;
            newDate.EndTime = end;

            dates.Add(newDate);

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.DateTable(Day, Date, StartTime, EndTime)" +
                                                    "VALUES (@day, @date, @startTime, @endTime)", conn);
                command.Parameters.Add("@day", System.Data.SqlDbType.NVarChar).Value = newDate.Day;
                command.Parameters.Add("@date", System.Data.SqlDbType.DateTime2).Value = newDate.ScheduleDate;
                command.Parameters.Add("@startTime", System.Data.SqlDbType.NVarChar).Value = newDate.StartTime;
                command.Parameters.Add("@endTime", System.Data.SqlDbType.NVarChar).Value = newDate.EndTime;
                command.ExecuteNonQuery();
            }
        }

        public void RemoveDate(Date oldDate)
        {

        }

        public void UpdateDate(DateTime newStart, DateTime newEnd)
        {

        }

        public List<Date> GetDates()
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
