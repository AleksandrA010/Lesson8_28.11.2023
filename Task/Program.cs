using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace Task
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Task Manager";
            string startText = "Добро пожаловать в Task Manager";
            string finalText = "Task Manager закрывается...";
            int timeSpleep = 1500;
            Screensaver StartScreensaver = new Screensaver(startText, timeSpleep);
            Screensaver FinalScreensaver = new Screensaver(finalText, timeSpleep);
            StartScreensaver.OutputScreensaver();
            var User = new User("172.16.255.2");
            bool flag = true;
            int InputID;
            string InputPassword;
            string answer;
            int listIndex;
            int YearDeadLine;
            int DayDeadline = 1;
            int MounthDeadline = 1;
            var Customers = new List<Customer>()
            {
                new Customer("John", "Cameron"),//ID John — 2405001
            };
            var Projects = new List<Project>()
            {
                new Project(Customers[0].GetFullName(), "Snake", "Description", DateTime.Now),
            };
            var TeamLeaders = new List<TeamLeader>() 
            {
                new TeamLeader("Tom", "Hamerton"),//ID Tom — 2405002
            };
            var Performers = new List<Performer>()
            {
                new Performer("Coll", "Merkel"),//ID Coll — 2405003
            };
            var Administrators = new List<Administrator>()
            {
                new Administrator("Alexander", "Arkhipov"),//ID Alekxander — 2405004
            };
            Customers[0].SetPassword("124");
            TeamLeaders[0].SetPassword("124");
            Performers[0].SetPassword("124");
            Administrators[0].SetPassword("124");
            while (flag)
            {
                ViewWindow.PrintMainWindow();
                Console.Write("Введите команду: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "LogAsAdministrator":
                        InputID = 0;
                        InputPassword = "";
                        User.RequestData(ref InputID, ref InputPassword);
                        if (InputID == 0) { break; }
                        bool flagAdministrator = User.TryLogTo(Administrators, InputID, InputPassword);
                        while (flagAdministrator)
                        {
                            listIndex = User.GetIndexUserInList(Administrators, InputID);
                            ViewWindow.PrintWindowAdministrator(Administrators, listIndex);
                            Console.Write("Введите команду: ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "AddNewProject":
                                    Console.Clear();
                                    string CustomerFullName = null;
                                    bool flagFind = true;
                                    while (flagFind)
                                    {
                                        User.PrintListCustomers(Customers);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\nВедите ID заказчика в списке.\nЕсли такого нет, то для его добавления и выбора введите AddNewCustomer\n\n==> ");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        answer = Console.ReadLine();
                                        if (answer == "AddNewCustomer")
                                        {
                                            User.AddNewCustomer(Customers);
                                            CustomerFullName = Customers[Customers.Count-1].GetFullName();
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            for (int i = 0; i < Customers.Count; i++)
                                            {
                                                int.TryParse(answer, out InputID);
                                                if (Customers[i].GetID() == InputID)
                                                {
                                                    CustomerFullName = Customers[i].GetFullName();
                                                    flagFind = false;
                                                    break;
                                                }
                                            }
                                            if (flagFind == true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Вы не верно ввели ID.");
                                                Console.Clear();
                                            }
                                        }
                                    }
                                  
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\nВведите название проекта: ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    string nameProject = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nВведите описание проекта.\nДля перехода на новую строчку нажмите 'Enter';\nДля отправки впишите *** в конце последнего предложения и нажмите 'Enter'.");
                                    Console.Write("==> ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    bool flagProjectDescription = true;
                                    string ProjectDescription = "\n    ";
                                    string LineDescription;
                                    while (flagProjectDescription)
                                    {
                                        LineDescription = Console.ReadLine();
                                        if (LineDescription.Contains("***"))
                                        {
                                            LineDescription = LineDescription.TrimEnd('*');
                                            ProjectDescription = ProjectDescription + LineDescription;
                                            flagProjectDescription = false;
                                            continue;
                                        }
                                        ProjectDescription = ProjectDescription + LineDescription + "\n    ";
                                    }
                                    bool tryflagDeadLine = true;
                                    while (tryflagDeadLine)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\nВведите месяц дедлайна: ");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        int.TryParse(Console.ReadLine(), out MounthDeadline);
                                        if (MounthDeadline == 0 | MounthDeadline > 12)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nТакого мeсяца не существует.");
                                            continue;
                                        }
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\nВведите день дедлайна: ");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        int.TryParse(Console.ReadLine(), out DayDeadline);
                                        if (DayDeadline == 0 | DayDeadline > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nТакое дня в текущем месяце не существует.");
                                            continue;
                                        }
                                        tryflagDeadLine = false;
                                    }
                                    YearDeadLine = DateTime.Now.Year;
                                    Projects.Insert(0, new Project(CustomerFullName, nameProject, ProjectDescription, new DateTime(YearDeadLine, MounthDeadline, DayDeadline)));
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nПроект {nameProject} успешно добален.");
                                    ViewWindow.PrintTransition();
                                    break;
                                case "OpenListProjects":
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Список проектов.\n-------------------------\n");
                                    User.PrintListProject(Projects);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "OpenListAdministrators":
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Список администраторов.\n-------------------------\n");
                                    User.PrintListAdministrators(Administrators);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "OpenListTeamLeaders":
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Список руководителей проектов.\n-------------------------\n");
                                    User.PrintListTeamLeaders(TeamLeaders);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "OpenListPerformers":
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Список исполнителей.\n-------------------------\n");
                                    User.PrintListPerformers(Performers);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "OpenListCustomers":
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Список заказчиков.\n-------------------------\n");
                                    User.PrintListCustomers(Customers);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "AddNewAdministrator":
                                    User.AddNewAdministrator(Administrators);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "AddNewTeamLeader":
                                    User.AddNewTeamLeader(TeamLeaders);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "AddNewPerformer":
                                    User.AddNewPerformer(Performers);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "AddNewCustomer":
                                    User.AddNewCustomer(Customers);
                                    ViewWindow.PrintTransitionWithWait();
                                    break;
                                case "Back":
                                    flagAdministrator = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nКоманда не найдена.");
                                    ViewWindow.PrintTransition();
                                    break;
                            }
                        }
                        break;
                    case "LogAsTeamLeader":
                        InputID = 0;
                        InputPassword = "";
                        User.RequestData(ref InputID, ref InputPassword);
                        if (InputID == 0) { break; }
                        bool flagTeamLeader = User.TryLogTo(TeamLeaders, InputID, InputPassword);
                        while (flagTeamLeader)
                        {
                            listIndex = User.GetIndexUserInList(TeamLeaders, InputID);
                            ViewWindow.PrintWindowTeamLeader(TeamLeaders, listIndex);
                            Console.Write("Введите команду: ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            answer = Console.ReadLine();
                            int indexProject = 1;
                            switch (answer)
                            {
                                case "TakeNewProject":
                                    User.PrintListProject(Projects);
                                    bool flagTryIndexProject = true;
                                    while (flagTryIndexProject)
                                    {
                                        Console.Write("Введите порядковый номер проекта, который хотите взять: ");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        int.TryParse(Console.ReadLine(), out indexProject);
                                        if (indexProject > Projects.Count)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nВы пытаетесь взять не существующий проект.\n");
                                        }
                                        else if (Projects[indexProject - 1].GetStatus() == ProjectStatus.Execution)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nДанный проект уже взят.\n");
                                        }
                                        else if (Projects[indexProject - 1].GetStatus() == ProjectStatus.Closed)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nДанный проект уже закрыт.\n");
                                        }
                                        else { flagTryIndexProject = false; }
                                    }
                                    bool flagTasks = true;
                                    int number = 1;
                                    string taskDescription = null;
                                    int listPerformersIndex = 1;
                                    var listTasks = new List<Task>();
                                    while (flagTasks)
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nЗадача {number}.");
                                        Console.Write($"\nВведите описание задачи: ");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        taskDescription = Console.ReadLine();
                                        bool tryflagDeadLine = true;
                                        while (tryflagDeadLine)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("Введите месяц дедлайна: ");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            int.TryParse(Console.ReadLine(), out MounthDeadline);
                                            if (MounthDeadline == 0 | MounthDeadline > 12)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("\nТакого мeсяца не существует.\n");
                                                continue;
                                            }
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("Введите день дедлайна: ");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            int.TryParse(Console.ReadLine(), out DayDeadline);
                                            if (DayDeadline == 0 | DayDeadline > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("\nТакое дня в текущем месяце не существует.\n");
                                                continue;
                                            }
                                            tryflagDeadLine = false;
                                        }
                                        YearDeadLine = DateTime.Now.Year;
                                        User.PrintListPerformers(Performers);
                                        bool flagTryPerformer = true;
                                        while (flagTryPerformer)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("\nВведите порядковый номер исполнителя, которому хотите назначить задачу: ");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            int.TryParse(Console.ReadLine(), out listPerformersIndex);
                                            if (listPerformersIndex > Performers.Count | listPerformersIndex <= 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("\nВы пытаетесь выбрать не существующего исполнителя.");
                                                continue;
                                            }
                                            flagTryPerformer = false;
                                        }
                                        listTasks.Add(new Task(taskDescription, new DateTime(YearDeadLine, MounthDeadline, DayDeadline), TeamLeaders[listIndex].GetFullName(), Performers[listPerformersIndex - 1].GetFullName(), number));
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\nДля завершения формирования задач и их отправки введите go, для продолжения нажмите на 'Enter'.");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        answer = Console.ReadLine();
                                        if (answer == "go") { flagTasks = false; }
                                        number++;
                                    }
                                    TeamLeaders[listIndex].TakeProject(Projects[indexProject - 1], listTasks);
                                    break;
                                case "OpenMyProjects":
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Ваши проекты.");
                                    Console.WriteLine("-------------------------------------------\n");
                                    TeamLeaders[listIndex].GetMyListProjectsTeamLeader();
                                    ViewWindow.PrintWindowTeamLeaderCommands();
                                    Console.Write("Введите команду: ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    answer = Console.ReadLine();
                                    bool flagTeamLeaderCommandReports = true;
                                    while (flagTeamLeaderCommandReports)
                                    {
                                        switch (answer)
                                        {
                                            case "OpenTask":
                                                TeamLeaders[listIndex].GetMyListProjectsTeamLeader();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("\nВведите порядковый номер проекта: ");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                int.TryParse(Console.ReadLine(), out int numberProject);
                                                TeamLeaders[listIndex].ReturnListProjects()[numberProject].PrintListTasks();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("\nВведите порядковый номер задачи: ");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                int.TryParse(Console.ReadLine(), out int numberTask);
                                                TeamLeaders[listIndex].ReturnListProjects()[numberProject].ReturnListTasks()[numberTask].PrintListReports();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("\nВведите порядковый номер отчёта для работы с ним: ");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                int.TryParse(Console.ReadLine(), out int numberReport);
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("\nВведите Yes/No для принятия/отклонения отчёта: ");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                answer = Console.ReadLine();
                                                if (answer == "Yes")
                                                {
                                                    TeamLeaders[listIndex].SendAnswer(true, TeamLeaders[listIndex].ReturnListProjects()[numberProject].ReturnListTasks()[numberTask].ReturnListReports()[numberReport], TeamLeaders[listIndex].ReturnListProjects()[numberProject].ReturnListTasks()[numberTask].ReturnListReports()[numberReport].ReturnPerformer(Performers), listIndex);
                                                }
                                                else if (answer == "No")
                                                {
                                                    TeamLeaders[listIndex].SendAnswer(false, TeamLeaders[listIndex].ReturnListProjects()[numberProject].ReturnListTasks()[numberTask].ReturnListReports()[numberReport], TeamLeaders[listIndex].ReturnListProjects()[numberProject].ReturnListTasks()[numberTask].ReturnListReports()[numberReport].ReturnPerformer(Performers), listIndex);
                                                }
                                                break;
                                            case "back":
                                                flagTeamLeaderCommandReports = false;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    break;
                                case "Back":
                                    flagTeamLeader = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nКоманда не найдена.");
                                    ViewWindow.PrintTransition();
                                    break;
                            }
                        }
                        break;
                    case "LogAsPerformer":
                        InputID = 0;
                        InputPassword = "";
                        if (InputID == 0) { break; }
                        User.RequestData(ref InputID, ref InputPassword);
                        bool flagPerformer = User.TryLogTo(Performers, InputID, InputPassword);
                        while (flagPerformer)
                        {
                            listIndex = User.GetIndexUserInList(Performers, InputID);
                            ViewWindow.PrintWindowPerformer(Performers, listIndex);
                            Console.Write("Введите команду: ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "TakeTask":
                                    Performers[listIndex].PrintListTaskPerformer();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\nВведите порядковый номер задание, которое хотите взять: ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    int.TryParse(Console.ReadLine(), out int numberTask);
                                    Performers[listIndex].TryTakeTask(true, numberTask - 1);
                                    break;
                                case "WriteReport":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("\nВведите текст отчёта: ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    string text = Console.ReadLine();
                                    Performers[listIndex].SendNewReport(text);
                                    break;
                                case "Back":
                                    flagPerformer = false;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nКоманда не найдена.");
                                    ViewWindow.PrintTransition();
                                    break;
                            }
                        }
                        break;
                    case "Exit":
                        flag = false;
                        FinalScreensaver.OutputScreensaver();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nКоманда не найдена.");
                        ViewWindow.PrintTransition();
                        break;
                }
            }
        }
    }
}
