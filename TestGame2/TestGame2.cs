using System;
using System.ComponentModel.Composition;

using Abstracts;

namespace TestGame2
{
    [Export(typeof(IGame))]
    public class TestGame2 : GameBase, IGame
    {
        public string Name => "Test Game 2";

        public string Description => "This is just a test game.";

        public void Load()
        {
            Console.WriteLine("Test Game 2 Loaded!");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome, {name} to {Name}");

            Console.Read();

            //http://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
        }
    }
}
