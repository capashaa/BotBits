using System;
using System.IO;
using System.Linq;
using System.Threading;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits.Demo
{
    internal class Program
    {
        private static readonly BotBitsClient bot = new BotBitsClient();
        public static string path = $"{Directory.GetCurrentDirectory()}\\login.txt";
        private static void Main()
        {
            string login = "guest";
            string pass = "guest";
            EventLoader.Of(bot).LoadStatic<Program>();
            if (File.Exists(path)) 
            {
                string[] data = File.ReadAllLines(path);
                login = data[0];
                pass = data[1];
            }
            Login.Of(bot).WithEmail(login, pass).CreateJoinRoom("PW3ZY7DVF5c0I");
            Actions.Of(bot).ChangeSmiley(SmileyShape.Regular, SmileyColour.Yellow, SmileyBorder.White, SmileyEyes.Coy, SmileyMouth.Smile, SmileyAddon.Nothing, SmileyAbove.Nothing, SmileyBelow.Nothing, SmileyWings.Nothing);
            Blocks.Of(bot).Place(10, 10, Foreground.Basic.Cyan);
            Thread.Sleep(Timeout.Infinite);
        }
        [EventListener]
        static void On(ForegroundPlaceEvent e)
        {
            //Console.WriteLine(e.New.Block.Message2);
        }
    }
}