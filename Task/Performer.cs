using System;
using System.Collections.Generic;

namespace Task
{
    internal class Performer : Person
    {
        private List<Report> reports = new List<Report>();
        private List<Task> tasks = new List<Task>();
        private Task task;
        public Performer(string FirstName, string SecondName) : base(FirstName, SecondName)
        {
            task = null;
        }
        public void GiveTask(Task task)
        {
            tasks.Add(task);
        }
        public void TryTakeTask(bool answer, int indexTask)
        {
            if (answer) 
            {
                task = tasks[indexTask];
                tasks.Clear();
                reports.Clear();
            }
            else
            {
                tasks.Remove(tasks[indexTask]);
            }
        }
        public void SendNewReport(string TextReport)
        {
            reports.Add(new Report(TextReport, GetFullName()));
            task.AddNewReport(TextReport);
            task.SetTaskStatusOnInspection();
        }
        public void GetAnswerOnReport(bool answer, Report report)
        {
            if (answer) 
            {
                report.SetReportStatusAccepted();
            }
            else
            {
                report.SetReportStatusNotAccepted();
            }
        }
        public Task ReturnTaskPerformer()
        {
            return task;
        }
        public void DelegateATask(Performer performer)
        {
            task = null;
            performer.GiveTask(task);
        }
        public void PrintListTaskPerformer()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}){tasks[i]}");
            }
        }
    }
}
