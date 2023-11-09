using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Task
{
    internal class TeamLeader : Person
    {
        private List<Project> projects;
        public TeamLeader(string FirstName, string SecondName) : base(FirstName, SecondName)
        {
            projects = new List<Project>();
        }
        public void TakeProject(Project project, List<Task> tasks)
        {
            projects.Add(project);
            project.OpenProject(FullName, tasks);
        }
        public void AbandonProject(Project project)
        {
            projects.Remove(project);
            project.SetDefault();
        }
        private bool TryTakeProject(Project project)
        {
            if (project.GetStatus() == ProjectStatus.Execution)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данный проект уже взят, выберете другой.");
                return false;
            }
            else if (project.GetStatus() == ProjectStatus.Closed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данный проект уже закрыт, выберете другой.");
                return false;
            }
            return true;
        }
        public string GetListProjectsTeamLeader()
        {
            string resultString = "Проекты: ";
            if (projects.Count == 0)
            {
                return "Руководитель не имеет проектов.";
            }
            for (int i = 0; i < projects.Count; i++)
            {
                resultString = resultString + projects[i] + " ";
            }
            resultString += ".";
            return resultString;
        }
        public void GetMyListProjectsTeamLeader()
        {
            if (projects.Count == 0)
            {
                Console.WriteLine("Вы не имеете проектов.");
            }
            for (int i = 0; i < projects.Count; i++)
            {
                Console.WriteLine($"{i+1}) {projects[i]}\n");
                projects[i].PrintListTasks();
                Console.WriteLine();
            }
        }
        public void SendAnswer(bool answer, Report report, Performer performer, int indexProject)
        {
            performer.GetAnswerOnReport(answer, report);
            if (answer == true)
            {
                projects[indexProject].SetProjectTaskStatusCompleted(performer.ReturnTaskPerformer());
                for (int i = 0; projects[indexProject].ReturnListTasks().Count < i; i++)
                {
                    if (projects[indexProject].ReturnListTasks()[i].GetTaskStatus() != TaskStatuses.Completed)
                    {
                        return;
                    }
                    projects[indexProject].SetStatusClosed();
                }
            }
            else
            {
                projects[indexProject].SetProjectTaskStatusAtWork(performer.ReturnTaskPerformer());
            }
        }
        public List<Project> ReturnListProjects()
        {
            return projects;
        }
    }
}
