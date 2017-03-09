using System;
using System.ComponentModel.Composition;

using Abstracts;

namespace TestGame
{
    [Export(typeof(IGame))]
    public class TestGame : GameBase, IGame
    {
        public string Name => "Test Game";

        public string Description => "This is just a test game.";

        public void Load()
        {
            Console.WriteLine("Test Game Loaded!");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome, {name} to {Name}");

            Console.Read();

            //http://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
        }
    }
}
