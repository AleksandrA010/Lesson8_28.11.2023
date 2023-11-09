using System;

namespace Task
{
    public class Person
    {
        protected static int id = 2405000;
        protected string FirstName;
        protected string SecondName;
        protected string FullName;
        protected int ID;
        protected string Password;
        public Person(string FirstName, string SecondName) 
        {
            ID = id++;
            this.FirstName = FirstName; 
            this.SecondName = SecondName;
            FullName = FirstName + " " + SecondName + " #" + Convert.ToString(ID);
        }
        public override string ToString()
        {
            return FullName;
        }
        public void SetPassword(string Password)
        {
            this.Password = Password;
        }
        public string GetPassword()
        {
            return Password;
        }
        public int GetID()
        {
            return ID;
        }
        public string GetFirstName() { return FirstName; }
        public string GetSecondName() { return SecondName; }
        public string GetFullName() { return FullName;}
    }
}
