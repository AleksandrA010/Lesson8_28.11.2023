using System;
using System.Collections.Generic;

namespace Task
{
    enum ProjectStatus
    {
        Project,
        Execution,
        Closed
    }
    internal class Project
    {
        private string ProjectName;
        private string ProjectDescription;
        private DateTime Deadline;
        private string Customer;
        private string TeamLeader;
        private List<Task> ProjectTasks;
        private ProjectStatus Status;

        public Project(string Customer, string ProjectName, string ProjectDescription, DateTime DeadLine)
        {
            TeamLeader = null;
            this.ProjectName = ProjectName;
            this.Customer = Customer;
            this.ProjectDescription = ProjectDescription;
            Deadline = DeadLine;
            Status = ProjectStatus.Project;
        }
        public void SetDefault()
        {
            Status = ProjectStatus.Project;
            ProjectTasks.Clear();
            TeamLeader = null;

        }
        public void OpenProject(string teamLeader, List<Task> tasks)
        {
            SetStatusExecution();
            SetTeamLeader(teamLeader);
            ProjectTasks = tasks;
        }
        private void SetTeamLeader(string teamLeader)
        {
            TeamLeader = teamLeader;
        }
        private void SetStatusExecution()
        {
            Status = ProjectStatus.Execution;
        }
        public void SetStatusClosed()
        {
            Status = ProjectStatus.Closed;
        }
        public ProjectStatus GetStatus()
        {
            return Status;
        }
        public string GetTeamLeader()
        {
            if (TeamLeader == null)
            {
                return "Не указан";
            }
            return TeamLeader;
        }
        public string GetCustomer()
        {
            return Customer;
        }
        public string GetProjectDescription()
        {
            return ProjectDescription;
        }
        public string GetProjectName()
        {
            return ProjectName;
        }
        public DateTime GetDeadLine() { return Deadline; }
        public override string ToString()
        {
            return ProjectName;
        }
        public void PrintListTasks()
        {
            for (int i = 0; i < ProjectTasks.Count; i++)
            {
                ProjectTasks[i].PrintTaskForTeamLeader();
            }
        }
        public void SetProjectTaskStatusCompleted(Task task)
        {
            ProjectTasks[GetIndexTask(task)].SetTaskStatusCompeleted();
        }
        public void SetProjectTaskStatusAtWork(Task task)
        {
            ProjectTasks[GetIndexTask(task)].SetTaskStatusAtWork();
        }
        private int GetIndexTask(Task task)
        {
            return ProjectTasks.IndexOf(task);
        }
        public List<Task> ReturnListTasks()
        {
            return ProjectTasks;
        }
    }
}
