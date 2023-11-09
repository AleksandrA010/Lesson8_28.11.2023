using System;
using System.Collections.Generic;

namespace Task
{
    enum TaskStatuses
    {
        Assigned,
        AtWork,
        OnInspection,
        Completed
    }
    internal class Task
    {
        private string TaskDescription;
        private DateTime Deadline;
        private string InitiatorOfTheTask;
        private string Performer;
        private TaskStatuses TaskStatus;
        private List<Report> TaskReports;
        private int NumberTask;
        public Task(string TaskDescription, DateTime DeadLine, string InitiatorOfTheTask, string Performer, int NumberTask) 
        {
            this.TaskDescription = TaskDescription;
            Deadline = DeadLine;
            this.Performer = Performer;
            this.InitiatorOfTheTask = InitiatorOfTheTask;
            this.NumberTask = NumberTask;
            TaskStatus = TaskStatuses.Assigned;
            TaskReports = new List<Report>();
        }
        public void PrintTaskForTeamLeader()
        {
            Console.WriteLine($"--\nЗадача {NumberTask};\nОписание задачи — {TaskDescription};\nИсполнитель — {Performer};\nДедлайн — {Deadline};\nСтатус — {TaskStatus}.\n--\n");
        }
        public void AddNewReport(string ReportText)
        {
            TaskReports.Add(new Report(ReportText, Performer));
        }
        public void SetTaskStatusOnInspection()
        {
            TaskStatus = TaskStatuses.OnInspection;
        }
        public void SetTaskStatusCompeleted()
        {
            TaskStatus = TaskStatuses.Completed;
        }
        public void SetTaskStatusAtWork()
        {
            TaskStatus = TaskStatuses.AtWork;
        }
        public TaskStatuses GetTaskStatus()
        {
            return TaskStatus;
        }
        public int GetNumberTask()
        {
            return NumberTask;
        }
        public List<Report> ReturnListReports()
        {
            return TaskReports;
        }
        public void PrintListReports()
        {
            for (int i = 0; i < TaskReports.Count; i++)
            {
                TaskReports[i].PrintReport(i);
            }
        }
        public void PrintTaskForPerformer()
        {
            Console.WriteLine($"--\nЗадача {NumberTask};\nОписание задачи — {TaskDescription};\nРуководитель — {InitiatorOfTheTask};\nДедлайн — {Deadline};\nСтатус — {TaskStatus}.\n--\n");
        }
    }
}
