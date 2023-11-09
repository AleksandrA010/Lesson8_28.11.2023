using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Task
{
    enum ReportStatuses
    {
        Accepted,
        NotAccepted
    }
    internal class Report
    {
        private string ReportText;
        private DateTime DateOfCompletion;
        private string Performer;
        private ReportStatuses ReportStatus;
        public Report(string ReportText, string Performer)
        {
            this.ReportText = ReportText;
            this.Performer = Performer;
            DateOfCompletion = DateTime.Now;
        }
        public void SetReportStatusAccepted()
        {
            ReportStatus = ReportStatuses.Accepted;
        }
        public void SetReportStatusNotAccepted()
        {
            ReportStatus = ReportStatuses.NotAccepted;
        }
        public void PrintReport(int number)
        {
            Console.WriteLine($"--{number}.\nОтчёт: {ReportText}\nДата публикации: {DateOfCompletion}\nСтатус: {ReportStatus}\n\n");
        }
        public Performer ReturnPerformer(List<Performer> performers)
        {
            string id = "";
            for (int i = 0; i < Performer.Length; i++)
            {
                if (Performer[i] == '#')
                {
                    for (int j = i+1; j < Performer.Length; j++)
                    {
                        id += Performer;
                    }
                    break;
                }
            }
            int intId = int.Parse(id);
            for (int i = 0; i < performers.Count; i++)
            {
                if (intId == performers[i].GetID())
                {
                    return performers[i];
                }
            }
            return null;
        }
        public override string ToString()
        {
            return ReportText;
        }
    }
}
