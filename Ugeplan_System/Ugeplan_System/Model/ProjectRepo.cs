﻿using System;
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

                SqlCommand command = new SqlCommand("SELECT ProjectId, ProjectName, ProjectDescription, ProjectPriority, StartTime, EndTime FROM Project", conn);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        project = new Project();
                        project.ProjectId = int.Parse(reader["ProjectId"].ToString());
                        project.ProjectName = reader["ProjectName"].ToString();
                        project.Description = reader["ProjectDescription"].ToString();
                        project.Priority = int.Parse(reader["ProjectPriority"].ToString());
                        project.StartTime = reader["StartTime"].ToString();
                        project.EndTime = reader["EndTime"].ToString();

                        projects.Add(project);
                    }
                }
            }
        }

        public void AddProject(string projectName, string description, string startTime, string endTime, int priority, List<Employee> employees)
        {
            Project newProject = new Project(projects.Count + 1, projectName, description, startTime, endTime, priority, employees);

            projects.Add(newProject);

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Project(ProjectName, ProjectDescription, ProjectPriority, StartTime, EndTime) " +
                                                    "VALUES (@projectName, @projectDescription, @expectedResults, @projectPriority, @projectStatus, @startTime, @endTime)", conn);
                command.Parameters.Add("@projectName", System.Data.SqlDbType.NVarChar).Value = projectName;
                command.Parameters.Add("@projectDescription", System.Data.SqlDbType.NVarChar).Value = description;
                command.Parameters.Add("@projectPriority", System.Data.SqlDbType.Int).Value = priority;
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

        public void Update(int projectId, string projectName, string description, string startTime, string endTime, int priority, List<Employee> employees)
        {
            if(projects.Exists(p => p.ProjectId == projectId))
            {
                Project temp = projects.Find(p => p.ProjectId == projectId);
                temp.ProjectName = projectName;
                temp.Description = description;
                temp.StartTime = startTime;
                temp.EndTime = endTime;
                temp.Priority = priority;
                temp.Employees = employees;

                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Project SET ProjectName = @projectName, ProjectDescription = @projectDescription, ProjectPriority = @projectPriority, StartTime = @startTime, EndTime = @endTime" +
                                                        "WHERE ProjectId = @projectId", conn);

                    command.Parameters.Add("@projectName", System.Data.SqlDbType.NVarChar).Value = projectName;
                    command.Parameters.Add("@projectDescription", System.Data.SqlDbType.NVarChar).Value = description;
                    command.Parameters.Add("@projectPriority", System.Data.SqlDbType.Int).Value = priority;
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
