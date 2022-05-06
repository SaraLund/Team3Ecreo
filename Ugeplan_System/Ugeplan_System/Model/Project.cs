using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Priority { get; set; }
        public List<Employee> Employees { get; set; }

        public Project(int projectId, string projectName, string description, string startTime, string endTime, int priority, List<Employee> employees)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Priority = priority;
            Employees = employees;
        }

        public Project()
        {

        }

        public override string ToString()
        {
            return $"{ProjectName} : {Description} : {StartTime} : {EndTime} : {Priority}";
        }
    }
}
