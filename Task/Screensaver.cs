using System;
using System.Threading;

namespace Task
{
    internal class Screensaver
    {
        private int CenterX;
        private int CenterY;
        private int TimeSleep;
        private string Text;
        private ConsoleColor ColorText;
        public Screensaver(string Text, int TimeSleep, ConsoleColor ColorText = ConsoleColor.Green)
        {
            CenterX = Console.WindowWidth / 2 - Text.Length / 2;
            CenterY = Console.WindowHeight / 2 - 1;
            this.TimeSleep = TimeSleep;
            this.Text = Text;
            this.ColorText = ColorText;
        }
        public void OutputScreensaver()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(CenterX, CenterY);
            Console.ForegroundColor = ColorText;
            Console.WriteLine(Text);
            Thread.Sleep(TimeSleep);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = true;
        }
    }
}
