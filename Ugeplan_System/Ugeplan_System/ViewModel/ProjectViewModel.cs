using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.ViewModel
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ExpectedResults { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

        public ProjectViewModel(int projectId, string projectName, string description, string expectedResults, string startTime, string endTime, int priority, string status, List<EmployeeViewModel> employees)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            Description = description;
            ExpectedResults = expectedResults;
            StartTime = startTime;
            EndTime = endTime;
            Priority = priority;
            Status = status;
            Employees = employees;
        }

        public ProjectViewModel()
        {

        }

        public override string ToString()
        {
            return $"{ProjectName} : {Description} : {ExpectedResults} : {StartTime} : {EndTime} : {Priority} : {Status}";
        }
    }
}
