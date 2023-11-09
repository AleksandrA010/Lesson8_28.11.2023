using System;
using System.Collections.Generic;

namespace Task
{
    abstract class UserFunctionality
    {
        public bool TryLogTo(List<Administrator> Employees, int InputID, string InputPassword)
        {
            string passwordUser = FindPasswordUser(Employees, InputID);
            if (passwordUser == InputPassword)
            {
                return true;
            }
            else if (passwordUser == null)
            {
                ReturnFailing();
                return false;
            }
            else
            {
                ReturnFailing();
                return false;
            }
        }
        public bool TryLogTo(List<TeamLeader> Employees, int InputID, string InputPassword)
        {
            string passwordUser = FindPasswordUser(Employees, InputID);
            if (passwordUser == InputPassword)
            {
                return true;
            }
            else if (passwordUser == null)
            {
                ReturnFailing();
                return false;
            }
            else
            {
                ReturnFailing();
                return false;
            }
        }
        public bool TryLogTo(List<Performer> Employees, int InputID, string InputPassword)
        {
            string passwordUser = FindPasswordUser(Employees, InputID);
            if (passwordUser == InputPassword)
            {
                return true;
            }
            else if(passwordUser == null)
            {
                ReturnFailing();
                return false;
            }
            else
            {
                ReturnFailing();
                return false;
            }
        }
        private string FindPasswordUser(List<Administrator> Employees, int InputID)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].GetID() == InputID)
                {
                    return Employees[i].GetPassword();
                }
            }
            return null;
        }
        private string FindPasswordUser(List<TeamLeader> Employees, int InputID)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].GetID() == InputID)
                {
                    return Employees[i].GetPassword();
                }
            }
            return null;
        }
        private string FindPasswordUser(List<Performer> Employees, int InputID)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].GetID() == InputID)
                {
                    return Employees[i].GetPassword();
                }
            }
            return null;
        }
        private void ReturnFailing()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВы не верно ввели ID или пароль.");
            ViewWindow.PrintTransition();
        }
        public bool RequestData(ref int InputID, ref string InputPassword)
        {
            Console.Clear();
            InputID = RequestID();
            if (InputID == 0)
            {
                ReturnFailingID();
                return false;
            }
            InputPassword = RequestPasswordUser();
            return true;
        }
        private string RequestPasswordUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Введите ваш пароль: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string InputPassword = Console.ReadLine();
            return InputPassword;
        }
        private int RequestID()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Введите ваш ID: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            int.TryParse(Console.ReadLine(), out int InputID);
            return InputID;
        }
        private void ReturnFailingID()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nПри вводе ID не может быть букв или других спец. символов!");
            ViewWindow.PrintTransition(2000);
            Console.Clear();
        }
        public int GetIndexUserInList(List<Administrator> list, int InputID)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetID() == InputID)
                {
                    return i;
                }
            }
            return 0;
        }
        public int GetIndexUserInList(List<TeamLeader> list, int InputID)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetID() == InputID)
                {
                    return i;
                }
            }
            return 0;
        }
        public int GetIndexUserInList(List<Performer> list, int InputID)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetID() == InputID)
                {
                    return i;
                }
            }
            return 0;
        }
        public void AddNewCustomer(List<Customer> list)
        {
            string FirstName = RequestFirstName();
            string SecondName = RequestSecondName();
            string Password = RequestPassword();
            list.Add(new Customer(FirstName, SecondName));
            list[list.Count - 1].SetPassword(Password);
        }
        public void AddNewTeamLeader(List<TeamLeader> list)
        {
            string FirstName = RequestFirstName();
            string SecondName = RequestSecondName();
            string Password = RequestPassword();
            list.Add(new TeamLeader(FirstName, SecondName));
            list[list.Count - 1].SetPassword(Password);
        }
        public void AddNewAdministrator(List<Administrator> list)
        {
            string FirstName = RequestFirstName();
            string SecondName = RequestSecondName();
            string Password = RequestPassword();
            list.Add(new Administrator(FirstName, SecondName));
            list[list.Count - 1].SetPassword(Password);
        }
        public void AddNewPerformer(List<Performer> list)
        {
            string FirstName = RequestFirstName();
            string SecondName = RequestSecondName();
            string Password = RequestPassword();
            list.Add(new Performer(FirstName, SecondName));
            list[list.Count - 1].SetPassword(Password);
        }
        private string RequestFirstName()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.Write("Введите имя: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string FirstName = Console.ReadLine();
            Console.WriteLine();
            return FirstName;
        }
        private string RequestSecondName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Введите фамилию: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string SecondName = Console.ReadLine();
            Console.WriteLine();
            return SecondName;
        }
        private string RequestPassword()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Установите пароль: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string Password = Console.ReadLine();
            Console.WriteLine();
            return Password;
        }
        public void PrintListProject(List<Project> list)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}) -Status — {list[i].GetStatus()}\n\n   " +
                    $"-Название проекта — {list[i].GetProjectName()}\n\n   " +
                    $"-Описание проекта:\n {list[i].GetProjectDescription()}\n\n   " +
                    $"-Заказчик — {list[i].GetCustomer()}\n\n   " +
                    $"-Руководитель проекта — {list[i].GetTeamLeader()}\n\n   " +
                    $"-Дедлайн — {list[i].GetDeadLine()}\n\n");
            }
            Console.WriteLine("----------------------------------------------");
        }
        public void PrintListAdministrators(List<Administrator> list)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {list[i]}");
            }
            Console.WriteLine("----------------------------------------------");
        }
        public void PrintListCustomers(List<Customer> list)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {list[i]}");
            }
            Console.WriteLine("----------------------------------------------");
        }
        public void PrintListPerformers(List<Performer> list)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {list[i]}");
            }
            Console.WriteLine("----------------------------------------------");
        }
        public void PrintListTeamLeaders(List<TeamLeader> list)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {list[i]}\n   {list[i].GetListProjectsTeamLeader()}\n");
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}
