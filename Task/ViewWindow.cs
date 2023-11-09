using System;
using System.Collections.Generic;
using System.Threading;

namespace Task
{
    internal static class ViewWindow
    {
        public static void PrintTransition(int TimeSleep = 1000)
        {
            Console.CursorVisible = false;
            Thread.Sleep(TimeSleep);
            Console.Clear();
            Console.CursorVisible = true;
        }
        public static void PrintTransitionWithWait()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Для продолжения нажмите на любую клавишу.");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
        }
        public static void PrintMainWindow()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Открыта панель команд.\n-----------------------\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("LogAsAdministrator — войти как администратор.");
            Console.WriteLine("LogAsTeamLeader — войти как руководитель проектами.");
            Console.WriteLine("LogAsPerformer — войти как исполнитель.");
            Console.WriteLine("Exit — выход.");
            Console.WriteLine("----------------------------------------------------\n");
        }
            public static void PrintWindowAdministrator(List<Administrator> List, int AdministratorIndex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Здравствуйте {List[AdministratorIndex]}.\n-----------------------\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("OpenListProjects — открыть лист проектов.");
            Console.WriteLine("OpenListCustomers — открыть лист заказчиков.");
            Console.WriteLine("OpenListTeamLeaders — открыть лист руководителей проектов.");
            Console.WriteLine("OpenListPerformers — открыть лист исполнителей.");
            Console.WriteLine("OpenListAdministrators — открыть лист администраторов.");
            Console.WriteLine("AddNewProject — добавить новый проект.");
            Console.WriteLine("AddNewCustomer — добавить нового заказчика.");
            Console.WriteLine("AddNewTeamLeader — добавить нового руководителя.");
            Console.WriteLine("AddNewPerformer — добавить нового исполнителя.");
            Console.WriteLine("AddNewAdministrator — добавить нового администратора.");
            Console.WriteLine("Back — вернуться назад.");
            Console.WriteLine("----------------------------------------------------\n");
        }
        public static void PrintWindowTeamLeader(List<TeamLeader> List, int TeamLeaderIndex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Здравствуйте {List[TeamLeaderIndex]}.\n-----------------------\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("TakeNewProject — взять новый проект.");
            Console.WriteLine("OpenMyProjects — открыть взятые проекты для просмотра/работы с ними.");
            Console.WriteLine("Back — вернуться назад.");
            Console.WriteLine("----------------------------------------------------\n");
        }
        public static void PrintWindowPerformer(List<Performer> List, int PerformerIndex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Здравствуйте {List[PerformerIndex]}.\n-----------------------\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Back — вернуться назад.");
            Console.WriteLine("----------------------------------------------------\n");
        }
        public static void PrintWindowTeamLeaderCommands()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n----------------------------------------------------");
            Console.WriteLine("OpenTask — открыть отчёты по задаче.");
            Console.WriteLine("Back — вернуться назад.");
            Console.WriteLine("----------------------------------------------------\n");
        }
    }
}
