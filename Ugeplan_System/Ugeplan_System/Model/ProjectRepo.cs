using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugeplan_System.Model
{
    public class ProjectRepo
    {
        private List<Project> projects = new List<Project>();
        private static readonly string connStr = "Server=10.56.8.36;Database=PEDB03;User Id=PE-03;Password=OPENDB_03";

        public ProjectRepo()
        {
            InitializeRepo();
        }

        public void InitializeRepo()
        {
            Project project;

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ProjectId, ProjectName, ProjectDescription, ExpectedResults, ProjectPriority, ProjectStatus, StartTime, EndTime FROM Project");

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        project = new Project();
                        project.ProjectId = int.Parse(reader["ProjectId"].ToString());
                        project.ProjectName = reader["ProjectName"].ToString();
                        project.Description = reader["ProjectDescription"].ToString();
                        project.ExpectedResults = reader["ExpectedResults"].ToString();
                        project.Priority = int.Parse(reader["ProjectPriority"].ToString());
                        project.Status = reader["ProjectStatus"].ToString();
                        project.StartTime = reader["StartTime"].ToString();
                        project.EndTime = reader["EndTime"].ToString();

                        projects.Add(project);
                    }
                }
            }
        }

        public void AddProject(string projectName, string description, string expectedResults, string startTime, string endTime, int priority, string status, List<Employee> employees)
        {
            Project newProject = new Project(projects.Count + 1, projectName, description, expectedResults, startTime, endTime, priority, status, employees);

            projects.Add(newProject);

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Project(ProjectName, ProjectDescription, ExpectedResults, ProjectPriority, ProjectStatus, StartTime, EndTime) " +
                                                    "VALUES (@projectName, @projectDescription, @expectedResults, @projectPriority, @projectStatus, @startTime, @endTime)", conn);
                command.Parameters.Add("@projectName", System.Data.SqlDbType.NVarChar).Value = projectName;
                command.Parameters.Add("@projectDescription", System.Data.SqlDbType.NVarChar).Value = description;
                command.Parameters.Add("@expectedResults", System.Data.SqlDbType.NVarChar).Value = expectedResults;
                command.Parameters.Add("@projectPriority", System.Data.SqlDbType.Int).Value = priority;
                command.Parameters.Add("@status", System.Data.SqlDbType.NVarChar).Value = status;
                command.Parameters.Add("@startTime", System.Data.SqlDbType.NVarChar).Value = startTime;
                command.Parameters.Add("@endTime", System.Data.SqlDbType.NVarChar).Value = endTime;

                command.ExecuteNonQuery();
            }
        }

        public void RemoveProject(Project project)
        {
            if (projects.Contains(project))
            {
                projects.Remove(project);

                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM Project WHERE ProjectId = @projectId", conn);

                    command.Parameters.Add("@projectId", System.Data.SqlDbType.Int).Value = project.ProjectId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(int projectId, string projectName, string description, string expectedResults, string startTime, string endTime, int priority, string status, List<Employee> employees)
        {
            if(projects.Exists(p => p.ProjectId == projectId))
            {
                Project temp = projects.Find(p => p.ProjectId == projectId);
                temp.ProjectName = projectName;
                temp.Description = description;
                temp.ExpectedResults = expectedResults;
                temp.StartTime = startTime;
                temp.EndTime = endTime;
                temp.Priority = priority;
                temp.Status = status;
                temp.Employees = employees;

                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Project SET ProjectName = @projectName, ProjectDescription = @projectDescription, ExpectedResults = @expectedResults, ProjectPriority = @projectPriority, ProjectStatus = @projectStatus, StartTime = @startTime, EndTime = @endTime" +
                                                        "WHERE ProjectId = @projectId", conn);

                    command.Parameters.Add("@projectName", System.Data.SqlDbType.NVarChar).Value = projectName;
                    command.Parameters.Add("@projectDescription", System.Data.SqlDbType.NVarChar).Value = description;
                    command.Parameters.Add("@expectedResults", System.Data.SqlDbType.NVarChar).Value = expectedResults;
                    command.Parameters.Add("@projectPriority", System.Data.SqlDbType.Int).Value = priority;
                    command.Parameters.Add("@status", System.Data.SqlDbType.NVarChar).Value = status;
                    command.Parameters.Add("@startTime", System.Data.SqlDbType.NVarChar).Value = startTime;
                    command.Parameters.Add("@endTime", System.Data.SqlDbType.NVarChar).Value = endTime;
                    command.Parameters.Add("@projectId", System.Data.SqlDbType.Int).Value = projectId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Project> GetAllProjects()
        {
            return projects;
        }

        public Project GetProjectById(int projectId)
        {
            if(!projects.Exists(x => x.ProjectId == projectId))
            {
                return null;
            }

            return projects.Find(x => x.ProjectId == projectId);
        }
    }
}
