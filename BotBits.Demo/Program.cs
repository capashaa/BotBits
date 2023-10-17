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
            Login.Of(bot).WithEmail(login, pass).CreateJoinRoom("PW01");
            /*Actions.Of(bot).ChangeSmiley(SmileyShape.Regular, SmileyColour.Yellow, 
                SmileyBorder.White, SmileyEyes.Coy, SmileyMouth.Smile, SmileyAddon.Nothing, 
                SmileyAbove.Nothing, SmileyBelow.Nothing, SmileyWings.Nothing);*/
            //Blocks.Of(bot).Place(2, 2, Foreground.Basic.Green);
            Thread.Sleep(Timeout.Infinite);
        }
        
    }
}